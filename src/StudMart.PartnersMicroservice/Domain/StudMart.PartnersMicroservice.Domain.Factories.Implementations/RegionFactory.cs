using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Region;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class RegionFactory(ICountriesRepository countryRepository, IRegionsRepository regionRepository) : IRegionFactory
{
    public async Task<IResult> Create(RegionFactoryContract factoryContract, CancellationToken cancellationToken = default)
    {
        var name = new RegionName(factoryContract.Name);
        var verification = await regionRepository.GetByNameAsync(name, cancellationToken);
        if(verification is not null)
            return new RegionAlreadyExistsResult(verification);
        var country = await countryRepository.GetByIdAsync(factoryContract.CountryId, cancellationToken);
        if (country is null)
            return new CountryNotFoundResult(factoryContract.CountryId);
        var region = new Region(country, name);
        country.AddRegion(region);
        return new RegionCreatedResult(region);
    }
}