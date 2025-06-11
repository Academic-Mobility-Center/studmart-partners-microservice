using FluentValidation;
using Grafana.OpenTelemetry;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;
using StudMart.PartnersMicroservice.Presentation.WebHost.Helpers;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
var section = builder.Configuration.GetSection("ServiceUrls");
var urls = section.Get<ServiceUrls>();
if(urls is null)
    throw new NullReferenceException($"{nameof(ServiceUrls)} is null");
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
});

builder.Services.AddOpenTelemetry()
    .ConfigureResource(r => r
        .AddService(
            serviceName: "partners-microservice",
            serviceVersion: typeof(Program).Assembly.GetName().Version?.ToString() ?? "unknown",
            serviceInstanceId: Environment.MachineName))
    .WithTracing(tracing =>
    {
        tracing
            .SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(builder.Environment.ApplicationName))
            .AddAspNetCoreInstrumentation()
            .AddEntityFrameworkCoreInstrumentation()
            .SetSampler(new AlwaysOnSampler())
            .UseGrafana(config => config.ResourceDetectors.Add(ResourceDetector.Container));
    })
    .WithMetrics(metrics =>
    {
        metrics
            .SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(builder.Environment.ApplicationName))
            .AddAspNetCoreInstrumentation()
            .AddRuntimeInstrumentation()
            .AddProcessInstrumentation()
            .UseGrafana(config => config.ResourceDetectors.Add(ResourceDetector.Container));
    });

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole(options =>
{
    options.IncludeScopes = true;
    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss";
});

builder.Logging.AddOpenTelemetry(logging => logging.UseGrafana());

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var rabbitSettings = builder.Configuration.GetSection("RabbitMq");
builder.Services.Configure<RabbitSettings>(rabbitSettings);
var dbSettings = builder.Configuration.GetRequiredSection("Database");

var settings = dbSettings.Get<DatabaseSettings>();
if(settings is null)
    throw new NullReferenceException("Database settings not found");
var connectionString = $"Host={settings.Host};Port={settings.Port};Database={settings.Db};Username={settings.Username};Password={settings.Password};";
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
builder.Services.AddScoped<IDescriptionRequestsRepository, DescriptionRequestsRepository>();
builder.Services.AddScoped<IDescriptionRequestFactory, DescriptionRequestFactory>();
builder.Services.AddHealthChecks().AddDbContextCheck<DataContext>();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(ICreateCommand<>).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(IGetAllRequest<>).Assembly);
    configuration.RegisterServicesFromAssemblyContaining<PartnerCreatedNotification>();
    configuration.Lifetime = ServiceLifetime.Scoped;
});
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("S3ProtectionClient", client =>
{
    client.BaseAddress = new Uri(urls.FilesService); // или из конфигурации
});

builder.Services.AddSingleton<IXmlRepository>(provider =>
{
    var factory = provider.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("S3ProtectionClient");
    return new HttpXmlRepository(client);
});

builder.Services.AddDataProtection()
    .SetApplicationName("StudMart")
    .AddKeyManagementOptions(options =>
    {
        options.XmlRepository = builder.Services.BuildServiceProvider().GetRequiredService<IXmlRepository>();
    });
// Добавьте аутентификацию через куки
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddCookie(IdentityConstants.ApplicationScheme,options =>
    {
        options.Cookie.Name = "StudMart";
        options.Cookie.SameSite = !string.IsNullOrEmpty(urls.Domain) ?  SameSiteMode.None : SameSiteMode.Lax;
        options.Cookie.SecurePolicy = !string.IsNullOrEmpty(urls.Domain) ? CookieSecurePolicy.Always : CookieSecurePolicy.None;
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        if(!string.IsNullOrEmpty(urls.Domain))
            options.Cookie.Domain = urls.Domain;
    })
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "StudMart";
    options.Cookie.SameSite = !string.IsNullOrEmpty(urls.Domain) ?  SameSiteMode.None : SameSiteMode.Lax;
    options.Cookie.SecurePolicy = !string.IsNullOrEmpty(urls.Domain) ? CookieSecurePolicy.Always : CookieSecurePolicy.None;
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    if(!string.IsNullOrEmpty(urls.Domain))
        options.Cookie.Domain = urls.Domain;
    
});
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
});

builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("healthz");
app.UseHttpsRedirection();
app.MigrateDatabase<DataContext>();
app.Run();