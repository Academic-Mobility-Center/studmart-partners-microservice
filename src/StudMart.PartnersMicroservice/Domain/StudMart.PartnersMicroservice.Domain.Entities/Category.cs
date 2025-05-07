using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Category : IntegerIdentifierNamedEntity<CategoryName>
{
    public Priority Priority { get; set; }
    protected Category(int id, CategoryName name, Priority priority) : base(id, name)
    {
        Priority = priority;
        
    }

    internal Category(CategoryName name, Priority priority) : this(0, name, priority)
    {
        
    }
}