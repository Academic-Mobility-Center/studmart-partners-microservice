using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;


namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class RegionName : SingleParameterValueObjectBase<string>
{
    internal RegionName(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public RegionName(string name) : this(name, new RegionNameValidator())
    {
        
    }


}