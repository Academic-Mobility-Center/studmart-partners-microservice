using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Phone;

public class InvalidLengthPhoneException(int length) : InvalidLengthExceptionBase(
    ValueObjectsLengthRules.MinPhoneNumberLength, ValueObjectsLengthRules.MaxPhoneNumberLength, length, "Phone");