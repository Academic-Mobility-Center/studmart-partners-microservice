using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.FirstName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class FirstNameValidator()
    : StringValidatorBase<InvalidFirstNameException, InvalidLengthFirstNameException, EmptyFirstNameException>(
        RegexValidationRules.NamePartValidationRegex, ValueObjectsLengthRules.MinFirstNameLength,
        ValueObjectsLengthRules.MaxFirstNameLength);