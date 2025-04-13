using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Synchronization.Abstractions;
using StudMart.PartnersMicroservice.WebHost.Helpers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitSettings = builder.Configuration.GetSection("RabbitMq");
builder.Services.Configure<RabbitSettings>(rabbitSettings);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(connectionString,
        optionsBuilder =>
            optionsBuilder.MigrationsAssembly("StudMart.PartnersMicroservice.Infrastructure.EntityFramework"));
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(StudMart.PartnersMicroservice.BusinessLogic.Mapping.CountryMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Mapping.RegionMappingProfile).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services
    .AddScoped<INamedEntityRepository<Country, int, CountryName>,
        EfNamedEntityRepositoryBase<Country, int, CountryName>>();
builder.Services
    .AddScoped<IRepository<Country, int>, EfRepositoryBase<Country, int>>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();

builder.Services
    .AddScoped<INamedEntityRepository<Region, int, RegionName>,
        EfNamedEntityRepositoryBase<Region, int, RegionName>>();
builder.Services
    .AddScoped<IRepository<Region, int>, EfRepositoryBase<Region, int>>();
builder.Services.AddScoped<IRegionsRepository, RegionsRepository>();

builder.Services.AddScoped<IEntityFactory<Country, int, CountryFactoryContract>, CountryFactory>();
builder.Services.AddSingleton<ICountryFactory, CountryFactory>();

builder.Services.AddScoped<IEntityFactory<Region, int, RegionFactoryContract>, RegionFactory>();
builder.Services.AddScoped<IRegionFactory, RegionFactory>();
builder.Services.AddScoped<IPartnersRepository, PartnersRepository>();
builder.Services.AddScoped<IPartnerFactory, PartnerFactory>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeeFactory, EmployeeFactory>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoryFactory, CategoryFactory>();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(ICreateCommand<,>).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(IGetAllRequest<>).Assembly);
    configuration.Lifetime = ServiceLifetime.Scoped;
});
builder.Services.AddSingleton<ISynchronizationService<PartnerModel>, PartnerSynchronizationService>();
builder.Services.AddSingleton<ISynchronizationService<RegionModel>, RegionSynchronizationService>();
builder.Services.AddSingleton<ISynchronizationService<CategoryModel>, CategorySynchronizationService>();
builder.Services.AddSingleton<ISynchronizationService<CountryModel>, CountrySynchronizationService>();
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