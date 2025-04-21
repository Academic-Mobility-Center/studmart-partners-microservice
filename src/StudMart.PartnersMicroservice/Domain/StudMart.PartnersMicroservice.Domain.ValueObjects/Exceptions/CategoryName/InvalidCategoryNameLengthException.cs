using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CategoryName;

public class InvalidCategoryNameLengthException(int length) : InvalidLengthExceptionBase(ValueObjectsLengthRules.MinCategoryNameLength, ValueObjectsLengthRules.MaxCategoryNameLength, length, "Category name")
{
    
}