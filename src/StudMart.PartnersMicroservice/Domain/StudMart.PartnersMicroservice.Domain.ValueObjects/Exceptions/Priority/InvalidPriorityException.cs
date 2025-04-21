using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Priority;

public class InvalidPriorityException(int priority) : InvalidValueObjectValueFormatExceptionBase("Priority", priority.ToString(), "be number from 1 to 100")
{
    public int Priority { get; } = priority;
    
}