using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.WebHost.Helpers;
using SudMart.PartnersMicroservice.Domain.Factories.Implementations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var connectionString = $"Host=localhost;Port=5432;Username=postgres;Password=postgres";

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(connectionString,
        optionsBuilder =>
            optionsBuilder.MigrationsAssembly("StudMart.PartnersMicroservice.Infrastructure.EntityFramework"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(ICreateCommand<,>).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services
    .AddScoped<INamedEntityRepository<Country, int, CountryName>,
        EfNamedEntityRepositoryBase<Country, int, CountryName>>();
builder.Services
    .AddScoped<IRepository<Country, int>, EfRepositoryBase<Country, int>>();
builder.Services.AddScoped<IEntityFactory<Country, int, CountryFactoryContract>, CountryFactory>();
builder.Services.AddSingleton<ICountryFactory, CountryFactory>();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(ICreateCommand<,>).Assembly);
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