using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Phone;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

/// <summary>
/// Class that helps validate mobile phone number of Employee
/// </summary>
public class PhoneValidator()
    : StringValidatorBase<InvalidPhoneNumberException, InvalidLengthPhoneException, EmptyPhoneException>(
        RegexValidationRules.PhoneValidationRegex, ValueObjectsLengthRules.MinPhoneNumberLength,
        ValueObjectsLengthRules.MaxPhoneNumberLength);