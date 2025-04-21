using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Email;

public class InvalidLengthEmailException(int length) : InvalidLengthExceptionBase(ValueObjectsLengthRules.MinEmailLength, ValueObjectsLengthRules.MaxEmailLength, length, "Email")
{
    
}