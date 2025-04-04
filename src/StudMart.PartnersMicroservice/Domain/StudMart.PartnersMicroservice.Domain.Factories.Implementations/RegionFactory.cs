using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class RegionFactory(IRepository<Country, int> countryRepository, IRepository<Region, int> regionRepository) : IRegionFactory
{
    public async Task<Region> Create(RegionFactoryContract factoryContract)
    {
        var country = await countryRepository.GetByIdAsync(factoryContract.CountryId);
        if (country is null)
            throw new NullReferenceException();
        var region = new Region(country, new RegionName(factoryContract.Name));
        country.AddRegion(region);
        return region;
    }
}