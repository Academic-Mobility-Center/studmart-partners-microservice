using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Bik;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class BikValidator() : StringValidatorBase<InvalidBikException, InvalidLengthBikException, EmptyBikException>(
    RegexValidationRules.BikValidationRegex, ValueObjectsLengthRules.MinBikLength, ValueObjectsLengthRules.MaxBikLength);