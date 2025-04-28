using System.Text.Json;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Country;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class CountryFactory(ICountriesRepository countriesRepository, ILogger<CountryFactory> logger) : ICountryFactory
{
    public async Task<IResult> Create(CountryFactoryContract factoryContract, CancellationToken cancellationToken = default)
    {
        var name = new CountryName(factoryContract.Name);
        var verification = await countriesRepository.GetByNameAsync(name, cancellationToken);
        if (verification is not null)
        {
            logger.LogWarning("Country with name {NameValue} already exists", name.Value);
            return new CountryAlreadyExistsResult(verification);
        }

        var country = new Country(name);
        logger.LogInformation(JsonSerializer.Serialize(country));
        return new CountryCreatedResult(country);
    }
}