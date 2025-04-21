using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Category : IntegerIdentifierNamedEntity<CategoryName>
{
    protected Category(int id, CategoryName name) : base(id, name)
    {
        
    }

    internal Category(CategoryName name) : this(0, name)
    {
        
    }
}