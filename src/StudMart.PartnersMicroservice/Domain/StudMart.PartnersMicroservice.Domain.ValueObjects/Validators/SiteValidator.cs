using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Site;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class SiteValidator()
    : StringValidatorBase<InvalidSiteException, InvalidLengthSiteException, EmptySiteException>(
        RegexValidationRules.SiteValidationRegex, ValueObjectsLengthRules.MinSiteLength,
        ValueObjectsLengthRules.MaxSiteLength);