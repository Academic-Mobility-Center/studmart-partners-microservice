using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

/// <summary>
/// Class that represents INN information
/// </summary>
public class Inn : SingleParameterValueObjectBase<long>
{
    internal Inn(long value, IValidator<long> validator) : base(value, validator)
    {
    }

    public Inn(long inn) : base(inn, new InnValidator())
    {
        
    }
}