using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Description;

public class InvalidLengthDescriptionException(int length) : InvalidLengthExceptionBase(ValueObjectsLengthRules.MinDescriptionLength, ValueObjectsLengthRules.MaxDescriptionLength, length, "Description")
{
    
}