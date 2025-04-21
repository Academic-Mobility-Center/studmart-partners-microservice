using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CategoryName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class CategoryNameValidator()
    : StringValidatorBase<InvalidCategoryNameException, InvalidCategoryNameLengthException, EmptyCategoryNameException>(
        RegexValidationRules.CategoryNameValidationRegex, ValueObjectsLengthRules.MinCategoryNameLength,
        ValueObjectsLengthRules.MaxCategoryNameLength);