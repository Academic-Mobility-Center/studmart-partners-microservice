using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Region(int id, RegionName region, Country country) : IntegerIdentifierEntity(id)
{
    public Country Country { get;  } = country ?? throw new ArgumentNullException(nameof(country));
    public RegionName Name { get;  } = region ?? throw new ArgumentNullException(nameof(region));
}