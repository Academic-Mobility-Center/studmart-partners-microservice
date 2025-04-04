using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

/// <summary>
/// Class that helps validate inn address of Employee
/// </summary>
public class EmailValidator() : StringValidatorBase<InvalidEmailException>(RegexValidationRules.EmailValidationRegex);
