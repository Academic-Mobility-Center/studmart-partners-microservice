using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidAccountNumberException(string number) : InvalidValueObjectValueFormatException("Account number", number)
{
    public string AccountNumber { get; } = number;

}