using Grafana.OpenTelemetry;
using Serilog;
using Serilog.Events;
using Serilog.Enrichers.Span;
using FluentValidation;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog.Templates;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Presentation.WebHost.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .Enrich.WithSpan()
    .WriteTo.Console(
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine}{Exception}"
    )
    .WriteTo.Console(
        formatter: new ExpressionTemplate("{ @l } | { TraceId } | { SpanId } | { Message }"),
        restrictedToMinimumLevel: LogEventLevel.Information
    )
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddOpenTelemetry()
    .WithMetrics(builder => builder.UseGrafana())
    .WithTracing(builder => builder.UseGrafana(config =>
        config.ResourceDetectors.Add(ResourceDetector.Container)));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var rabbitSettings = builder.Configuration.GetSection("RabbitMq");
builder.Services.Configure<RabbitSettings>(rabbitSettings);
var dbSettings = builder.Configuration.GetRequiredSection("Database");
builder.Configuration.AddEnvironmentVariables();
var settings = dbSettings.Get<DatabaseSettings>();
if(settings is null)
    throw new NullReferenceException("Database settings not found");
var connectionString = $"Host={settings.Host};Port={settings.Port};Database={settings.Db};Username={settings.Username};Password={settings.Password};";
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(connectionString,
        optionsBuilder =>
            optionsBuilder.MigrationsAssembly("StudMart.PartnersMicroservice.Infrastructure.EntityFramework"))
        .LogTo(Log.Logger.Information, LogLevel.Information, 
            DbContextLoggerOptions.SingleLine | DbContextLoggerOptions.UtcTime);
}); 

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(connectionString,
        optionsBuilder =>
            optionsBuilder.MigrationsAssembly("StudMart.PartnersMicroservice.Infrastructure.EntityFramework"));
});

builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(StudMart.PartnersMicroservice.BusinessLogic.Mapping.CountryMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Mapping.RegionMappingProfile).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IRegionsRepository, RegionsRepository>();
builder.Services.AddScoped<ICountryFactory, CountryFactory>();
builder.Services.AddScoped<IRegionFactory, RegionFactory>();
builder.Services.AddScoped<IPartnersRepository, PartnersRepository>();
builder.Services.AddScoped<IPartnerFactory, PartnerFactory>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeeFactory, EmployeeFactory>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoryFactory, CategoryFactory>();
builder.Services.AddHealthChecks().AddDbContextCheck<DataContext>();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(ICreateCommand<>).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(IGetAllRequest<>).Assembly);
    configuration.RegisterServicesFromAssemblyContaining<PartnerCreatedNotification>();
    configuration.Lifetime = ServiceLifetime.Scoped;
});
builder.Services.AddControllers();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapHealthChecks("healthz");
app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
    options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Information;
});
app.UseHttpLogging();
app.UseHttpsRedirection();
app.MigrateDatabase<DataContext>();
app.Run();