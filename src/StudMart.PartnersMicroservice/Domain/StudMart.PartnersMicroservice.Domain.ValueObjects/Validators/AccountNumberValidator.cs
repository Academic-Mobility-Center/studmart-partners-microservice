using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class AccountNumberValidator() : StringValidatorBase<InvalidAccountNumberException>(RegexValidationRules
    .AccountNumberValidationRegex);
