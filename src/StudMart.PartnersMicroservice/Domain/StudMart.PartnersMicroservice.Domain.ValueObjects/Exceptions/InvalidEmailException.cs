using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

/// <summary>
/// Exception that occurs if email is incorrect
/// </summary>
/// <param name="email">String that is incorrect email</param>
public class InvalidEmailException(string email) : InvalidValueObjectValueFormatException("Email", email)
{
    /// <summary>
    /// Invalid email value
    /// </summary>
    public string Email { get; } = email;
}
