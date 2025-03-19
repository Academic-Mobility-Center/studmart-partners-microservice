namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

/// <summary>
/// Exception that occurs if email is incorrect
/// </summary>
/// <param name="email">String that is incorrect email</param>
public class InvalidEmailException(string email) : FormatException
{
    /// <summary>
    /// Email that is incorrect
    /// </summary>
    public string Email { get; } = email;
    /// <summary>
    /// Exception message information
    /// </summary>
    public override string Message => $"{nameof(Email)} {Email} is incorrect";
}