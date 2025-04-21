using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Description;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class DescriptionValidator()
    : StringValidatorBase<InvalidDescriptionException, InvalidLengthDescriptionException, EmptyDescriptionException>(
        RegexValidationRules.DescriptionValidationRegex, ValueObjectsLengthRules.MinDescriptionLength,
        ValueObjectsLengthRules.MaxDescriptionLength);