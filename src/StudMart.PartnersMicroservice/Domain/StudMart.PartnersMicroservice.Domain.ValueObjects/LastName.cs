using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class LastName : NamedValueObject<string>
{
    internal LastName(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public LastName(string name) : base(name, new LastNameValidator())
    {
        
    }
}