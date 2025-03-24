using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Country : IntegerIdentifierEntity
{
    public CountryName Name { get;  }
    public Country(int id, CountryName countryName) : base(id)
    {
        Name = countryName ?? throw new ArgumentNullException(nameof(countryName));
    }
    
}