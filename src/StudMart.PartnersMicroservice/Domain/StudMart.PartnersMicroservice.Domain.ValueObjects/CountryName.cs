using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class CountryName : NamedValueObject<string>
{
    private CountryName(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public CountryName(string name) : this(name, new CountryNameValidator())
    {
        
    }
}