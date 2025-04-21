using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CategoryName;

public class InvalidCategoryNameException(string name) : InvalidNameException("Category name", name, "contains only russian and english letters and spaces")
{
    
}