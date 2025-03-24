using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;


/// <summary>
/// Class that represents Mobile phone of Employee
/// </summary>
public class Phone : SingleParameterValueObjectBase<string>
{
    internal Phone(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public Phone(string phone) : base(phone, new PhoneValidator())
    {
        
    }
}