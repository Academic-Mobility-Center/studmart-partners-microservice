using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class CategoryName : NamedValueObject<string>
{
    protected CategoryName(string name, IValidator<string> validator) : base(name, validator)
    {
        
    }

    public CategoryName(string name) : this(name, new CategoryNameValidator())
    {
        
    }
}