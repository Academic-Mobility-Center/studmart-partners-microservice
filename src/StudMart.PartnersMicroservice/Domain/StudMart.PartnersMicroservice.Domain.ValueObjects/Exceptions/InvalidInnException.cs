namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

/// <summary>
/// Exception that occurs if INN number is incorrect
/// </summary>
public class InvalidInnException(long inn) : FormatException
{
    /// <summary>
    /// Inn that is not correct
    /// </summary>
    public long Inn { get;  } = inn;
    /// <summary>
    /// Exception message with incorrect INN information
    /// </summary>
    public override string Message => $"INN {Inn} is incorrect";
}