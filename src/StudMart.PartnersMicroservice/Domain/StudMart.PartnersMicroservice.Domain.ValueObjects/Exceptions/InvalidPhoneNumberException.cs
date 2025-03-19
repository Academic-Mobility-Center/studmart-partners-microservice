namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;


/// <summary>
/// Exception that occurs if phone number is incorrect
/// </summary>
public class InvalidPhoneNumberException : FormatException
{
    /// <summary>
    /// Incorrect phone number
    /// </summary>
    public string Phone { get;  }
    /// <summary>
    /// Exception information message that phone number is incorrect
    /// </summary>
    public override string Message => $"Phone {Phone} is incorrect";
    /// <summary>
    /// Constructor that creates invalid phone error
    /// </summary>
    /// <param name="phone">Phone that is incorrect</param>
    public InvalidPhoneNumberException(string phone)
    {
        Phone = phone;
    }
}