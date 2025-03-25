using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Region : IntegerIdentifierNamedEntity<RegionName>
{
    public Region(int id, Country country, RegionName name) : base(id, name)
    {
        Country = country;
    }

    public Region(Country country, RegionName name) : this(0, country, name)
    {
        
    }

    public Country Country { get;  } 
}