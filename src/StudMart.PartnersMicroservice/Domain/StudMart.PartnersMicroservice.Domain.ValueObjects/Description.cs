using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class Description : SingleParameterValueObjectBase<string>
{
    protected Description(string value, IValidator<string> validator) : base(value, validator)
    {
        
    }

    public Description(string description) : this(description, new DescriptionValidator())
    {
        
    }
    
}