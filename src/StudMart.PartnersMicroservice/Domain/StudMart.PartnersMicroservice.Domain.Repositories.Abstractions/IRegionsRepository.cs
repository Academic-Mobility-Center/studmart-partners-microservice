using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IRegionsRepository : INamedEntityRepository<Region, int , RegionName>
{
    Task<IEnumerable<Region>> GetAllRegionsByCountryAsync(Country country, CancellationToken cancellationToken = default);
}