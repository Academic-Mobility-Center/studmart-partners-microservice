using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class FirstName : NamedValueObject<string>
{
    internal FirstName(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public FirstName(string firstName) : this(firstName, new FirstNameValidator()) 
    {
        
    }
}