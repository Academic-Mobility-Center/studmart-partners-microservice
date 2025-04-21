using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Priority;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class PriorityValidator : IValidator<int>
{
    public void Validate(int value)
    {
        if (value is < 0 or > 100)
            throw new InvalidPriorityException(value);
    }
}