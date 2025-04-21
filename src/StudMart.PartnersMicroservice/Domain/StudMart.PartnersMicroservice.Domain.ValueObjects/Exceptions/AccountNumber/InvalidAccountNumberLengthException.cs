using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.AccountNumber;

public class InvalidAccountNumberLengthException(int length) : InvalidLengthExceptionBase(
    ValueObjectsLengthRules.MinAccountNumberLength, ValueObjectsLengthRules.MaxAccountNumberLength, length,
    "Account number")
{
}