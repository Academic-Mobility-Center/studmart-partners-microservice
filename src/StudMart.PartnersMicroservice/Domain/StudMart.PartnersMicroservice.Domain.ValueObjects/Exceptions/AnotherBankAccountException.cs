namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class AnotherBankAccountException(string bik, string accountNumber) : Exception("Another bank account")
{
    public string Bik { get; } = bik;
    public string AccountNumber { get; } = accountNumber;
}