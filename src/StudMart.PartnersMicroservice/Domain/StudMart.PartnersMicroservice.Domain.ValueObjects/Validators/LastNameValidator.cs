using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.LastName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class LastNameValidator() : StringValidatorBase<InvalidLastNameException, InvalidLengthLastNameException, EmptyLastNameException>(
    RegexValidationRules.NamePartValidationRegex, ValueObjectsLengthRules.MinLastNameLength,
    ValueObjectsLengthRules.MaxLastNameLength);
