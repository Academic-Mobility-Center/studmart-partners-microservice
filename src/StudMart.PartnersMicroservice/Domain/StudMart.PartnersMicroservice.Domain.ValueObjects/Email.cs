using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

/// <summary>
/// Class that represents email address
/// </summary>
public class Email : SingleParameterValueObjectBase<string>
{
    internal Email(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public Email(string email) : this(email, new EmailValidator())
    {
        
    }
}