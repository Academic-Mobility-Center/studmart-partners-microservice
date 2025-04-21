using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.LastName;

public class InvalidLengthLastNameException(int length) : InvalidLengthExceptionBase(
    ValueObjectsLengthRules.MinLastNameLength, ValueObjectsLengthRules.MaxLastNameLength, length, "Last name");