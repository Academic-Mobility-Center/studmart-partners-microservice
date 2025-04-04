using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class Subtitle : SingleParameterValueObjectBase<string>
{
    protected Subtitle(string subtitle, IValidator<string> validator) : base(subtitle, validator)
    {
        
    }

    public Subtitle(string subtitle) : this(subtitle, new SubtitleValidator())
    {
        
    }
}