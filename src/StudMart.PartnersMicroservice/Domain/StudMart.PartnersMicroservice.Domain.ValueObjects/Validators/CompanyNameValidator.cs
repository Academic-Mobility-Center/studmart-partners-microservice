using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CompanyName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class CompanyNameValidator()
    : StringValidatorBase<InvalidCompanyNameException, InvalidLengthCompanyNameException, EmptyCompanyNameException>(
        RegexValidationRules.CompanyNameValidationRegex, ValueObjectsLengthRules.MinCompanyNameLength,
        ValueObjectsLengthRules.MaxCompanyNameLength);