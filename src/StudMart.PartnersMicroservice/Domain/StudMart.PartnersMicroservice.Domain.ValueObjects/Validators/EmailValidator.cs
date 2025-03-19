using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

/// <summary>
/// Class that helps validate inn address of Employee
/// </summary>
internal class EmailValidator : IValidator<string>
{
    /// <summary>
    /// Method that validates inn address to correct
    /// </summary>
    /// <param name="email">Email address to validate</param>
    /// <exception cref="InvalidEmailException"></exception>
    public void Validate(string email)
    {
        if (email is null
            || !Regex.IsMatch(email, RegexValidationRules.EmailValidationRegex, RegexOptions.IgnoreCase))
            throw new InvalidEmailException(email ?? "");
    }
}