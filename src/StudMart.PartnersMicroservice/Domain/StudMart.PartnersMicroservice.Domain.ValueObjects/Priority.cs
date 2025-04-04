using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class Priority : SingleParameterValueObjectBase<int>
{
    protected Priority(int priority, IValidator<int> validator) : base(priority, validator)
    {
        
    }

    public Priority(int priority) : this(priority, new PriorityValidator())
    {
        
    }
}