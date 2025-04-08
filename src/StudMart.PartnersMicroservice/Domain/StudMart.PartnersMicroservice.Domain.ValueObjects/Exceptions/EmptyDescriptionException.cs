namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class EmptyDescriptionException(string description) : NullReferenceException($"Description {description} is empty")
{
    
}