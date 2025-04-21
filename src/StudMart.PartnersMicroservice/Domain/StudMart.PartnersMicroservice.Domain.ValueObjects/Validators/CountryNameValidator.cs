using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CountryName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class CountryNameValidator()
    : StringValidatorBase<InvalidCountryNameException, InvalidLengthCountryNameException, EmptyCountryNameException>(
        RegexValidationRules.CountryNameValidationRegex, ValueObjectsLengthRules.MinCountryNameLength,
        ValueObjectsLengthRules.MaxCountryNameLength);