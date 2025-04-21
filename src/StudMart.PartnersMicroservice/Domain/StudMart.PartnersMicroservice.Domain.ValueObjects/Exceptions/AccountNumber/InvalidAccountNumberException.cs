using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.AccountNumber;

public class InvalidAccountNumberException(string number) : InvalidValueObjectValueFormatExceptionBase("Account number", number, " contains only 20 digits")
{
    public string AccountNumber { get; } = number;

}