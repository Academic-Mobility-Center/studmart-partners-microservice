using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var rabbitSettings = builder.Configuration.GetSection("RabbitMq");
builder.Services.Configure<RabbitSettings>(rabbitSettings);
var dbSettings = builder.Configuration.GetRequiredSection("Database");
builder.Configuration.AddEnvironmentVariables();
var settings = dbSettings.Get<DatabaseSettings>();
if(settings is null)
    throw new NullReferenceException("Database settings not found");
var connectionString = $"Host=192.168.99.12;Port=5432;Database=Partners;Username=postgres;Password=postgres;sslmode=disable";
Console.WriteLine(connectionString);
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
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(ICreateCommand<>).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(IGetAllRequest<>).Assembly);
    configuration.RegisterServicesFromAssemblyContaining<PartnerCreatedNotification>();
    configuration.Lifetime = ServiceLifetime.Scoped;
});
builder.Services.AddControllers();
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
app.UseHttpsRedirection();
app.MigrateDatabase<DataContext>();
app.Run();