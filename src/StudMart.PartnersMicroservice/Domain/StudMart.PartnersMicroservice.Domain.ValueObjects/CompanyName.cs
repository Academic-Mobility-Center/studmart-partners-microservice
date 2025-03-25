using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class CompanyName : NamedValueObject<string>
{
    private CompanyName(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public CompanyName(string name) : base(name, new CompanyNameValidator())
    {
        
    }
}