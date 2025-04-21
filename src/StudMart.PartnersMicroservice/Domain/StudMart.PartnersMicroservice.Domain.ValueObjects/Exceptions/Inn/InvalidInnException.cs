using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Inn;

/// <summary>
/// Exception that occurs if INN number is incorrect
/// </summary>
public class InvalidInnException(long inn) : InvalidValueObjectValueFormatExceptionBase("Inn", inn.ToString(), "have only digits")
{
    /// <summary>
    /// Inn that is not correct
    /// </summary>
    public long Inn { get;  } = inn;
}