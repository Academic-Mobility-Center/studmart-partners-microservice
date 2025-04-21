using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Description;

public class InvalidDescriptionException(string description) : InvalidValueObjectValueFormatExceptionBase("Description", description, "be safe for db, not contains code")
{
    
}