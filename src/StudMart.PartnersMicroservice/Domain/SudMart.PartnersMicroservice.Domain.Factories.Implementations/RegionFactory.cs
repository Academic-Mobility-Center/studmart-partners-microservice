using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace SudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class RegionFactory : IRegionFactory
{
    public Task<Region> Create(RegionFactoryContract factoryContract)
    {
        throw new NotImplementedException();
    }
}