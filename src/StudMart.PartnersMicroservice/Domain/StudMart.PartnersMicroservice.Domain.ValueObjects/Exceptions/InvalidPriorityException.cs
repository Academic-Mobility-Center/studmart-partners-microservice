using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidPriorityException(int priority) : InvalidValueObjectValueFormatException("Priority", priority.ToString())
{
    public int Priority { get; } = priority;
    
}