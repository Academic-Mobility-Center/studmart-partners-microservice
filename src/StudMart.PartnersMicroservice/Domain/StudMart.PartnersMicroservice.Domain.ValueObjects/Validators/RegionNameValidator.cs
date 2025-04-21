using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.RegionName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class RegionNameValidator()
    : StringValidatorBase<InvalidRegionNameException, InvalidLengthRegionNameException, EmptyRegionNameException>(
        RegexValidationRules.RegionNameValidationRegex, ValueObjectsLengthRules.MinRegionNameLength,
        ValueObjectsLengthRules.MaxRegionNameLength);