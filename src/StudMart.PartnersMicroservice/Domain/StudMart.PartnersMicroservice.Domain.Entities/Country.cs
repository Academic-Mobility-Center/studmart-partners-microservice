using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Country : IntegerIdentifierNamedEntity<CountryName>
{
    private readonly ICollection<Region> _regions = [];
    public IReadOnlyCollection<Region> Regions => _regions.ToList().AsReadOnly();
    protected Country(int id, CountryName name) : base(id, name)
    {
       
    }

    public Country(CountryName name) : this(0, name)
    {
        
    }

    public void AddRegion(Region region)
    {
        if (_regions.Any(r => r == region))
            return;
        _regions.Add(region);
    }

    public void RemoveRegion(Region region)
    {
        var found = _regions.FirstOrDefault(r => r== region);
        if (found is null)
            return;
        _regions.Remove(region);

    }
    
}