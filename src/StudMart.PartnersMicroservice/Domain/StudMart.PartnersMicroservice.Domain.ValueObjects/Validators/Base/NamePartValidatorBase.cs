using StudMart.PartnersMicroservice.Common.Helpers;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

public class NamePartValidatorBase<TException>()
    : StringValidatorBase<TException>(RegexValidationRules.NamePartValidationRegex) where TException : Exception;