using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Region : IntegerIdentifierEntity
{
    public Region(int id, Country country, RegionName name) : base(id)
    {
        Country = country;
        Name = name;
    }

    public Region(Country country, RegionName name) : this(0, country, name)
    {
        
    }

    public Country Country { get;  } 
    public RegionName Name { get;  } 
}