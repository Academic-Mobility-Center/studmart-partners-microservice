using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class Site : SingleParameterValueObjectBase<string>
{
    private Site(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public Site(string value) : this(value, new SiteValidator())
    {
        
    }
}