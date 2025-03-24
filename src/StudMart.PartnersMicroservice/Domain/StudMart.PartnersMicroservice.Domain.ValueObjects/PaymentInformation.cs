using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class PaymentInformation : IValueObject
{
    private static readonly int[] Weights = [7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1];
    private static void ValidateCheckSum(string accountNumber, string bik)
    {
        var fullNumber = string.Concat(bik.AsSpan(6, 3), accountNumber);
        var sum = fullNumber.Select(t => t - '0').Select((digit, i) => digit * Weights[i]).Sum();
        if (sum % 10 != 0)
            throw new AnotherBankAccountException(bik, accountNumber);
    }
    private static void ValidateCorrespondentAccountNumberWithBik(string accountNumber, string bik)
    {
        
        // Для корреспондентских счетов первые 3 цифры должны совпадать
        // с последними 3 цифрами БИК
        if (!accountNumber.StartsWith(bik.Substring(6, 3)))
            throw new AnotherBankAccountException(bik, accountNumber);
        // Проверка контрольных цифр
        
        ValidateCheckSum(accountNumber, bik);

    }

    private static void ValidateAccountNumberWithBik(string accountNumber, string bik) =>
        ValidateCheckSum(accountNumber, bik);

    public Bik Bik { get; set; }
    public AccountNumber AccountNumber { get; set; }
    public AccountNumber CorrespondentAccountNumber { get; set; }
    public PaymentInformation(Bik bik, AccountNumber accountNumber, AccountNumber correspondentAccountNumber)
    {
        ValidateCorrespondentAccountNumberWithBik(correspondentAccountNumber.Value, bik.Value );
        ValidateAccountNumberWithBik(accountNumber.Value, bik.Value);
        Bik = bik;
        AccountNumber = accountNumber;
        CorrespondentAccountNumber = correspondentAccountNumber;
    }
    
}