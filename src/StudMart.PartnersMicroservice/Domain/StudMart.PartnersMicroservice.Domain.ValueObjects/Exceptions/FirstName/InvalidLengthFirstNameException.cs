using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.FirstName;

public class InvalidLengthFirstNameException(int length) : InvalidLengthExceptionBase(
    ValueObjectsLengthRules.MinFirstNameLength, ValueObjectsLengthRules.MaxFirstNameLength, length, "First name")
{
}