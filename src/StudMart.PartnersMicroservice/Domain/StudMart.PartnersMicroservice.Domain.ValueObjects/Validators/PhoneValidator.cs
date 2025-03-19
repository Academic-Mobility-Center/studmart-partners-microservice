using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

/// <summary>
/// Class that helps validate mobile phone number of Employee
/// </summary>
internal class PhoneValidator : IValidator<string>
{
    /// <summary>
    /// Method that validates mobile phone number of employee
    /// </summary>
    /// <param name="phone">Mobile phone number to validate</param>
    /// <exception cref="InvalidPhoneNumberException">Occurs if mobile phone number has incorrect format</exception>
    public void Validate(string phone)
    {
        if (Regex.Match(phone, RegexValidationRules.PhoneValidationRegex).Success == false)
            throw new InvalidPhoneNumberException(phone);
    }
}