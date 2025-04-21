using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Country;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class CountryFactory(ICountriesRepository countriesRepository) : ICountryFactory
{
    public async Task<IResult> Create(CountryFactoryContract factoryContract, CancellationToken cancellationToken = default)
    {
        var name = new CountryName(factoryContract.Name);
        var verification = await countriesRepository.GetByNameAsync(name, cancellationToken);
        if (verification is not null)
            return new CountryAlreadyExistsResult(verification);
        var country = new Country(name);
        return new CountryCreatedResult(country);
    }
}