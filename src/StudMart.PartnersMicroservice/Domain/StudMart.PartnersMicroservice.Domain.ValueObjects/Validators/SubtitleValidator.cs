using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Subtitle;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class SubtitleValidator() :
    StringValidatorBase<InvalidSubtitleException, InvalidLengthSubtitleException, EmptySubtitleException>(
        RegexValidationRules.SubtitleValidationRegex, ValueObjectsLengthRules.MinSubtitleLength,
        ValueObjectsLengthRules.MaxSubtitleLength);