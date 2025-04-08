using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidDescriptionException(string description) : InvalidValueObjectValueFormatException("Description", description)
{
    
}