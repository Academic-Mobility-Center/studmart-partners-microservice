using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

/// <summary>
/// Exception that occurs if INN number is incorrect
/// </summary>
public class InvalidInnException(long inn) : InvalidValueObjectValueFormatException("Inn", inn.ToString())
{
    /// <summary>
    /// Inn that is not correct
    /// </summary>
    public long Inn { get;  } = inn;
}