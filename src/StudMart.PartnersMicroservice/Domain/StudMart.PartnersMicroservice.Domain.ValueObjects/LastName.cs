using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class LastName : SingleParameterValueObjectBase<string>
{
    internal LastName(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    internal LastName(string name) : base(name, new LastNameValidator())
    {
        
    }
}