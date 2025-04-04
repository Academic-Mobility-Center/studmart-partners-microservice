using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class CategoryNameValidator : IValidator<string>
{
    private const int MaxLength = 50;
    private const int MinLength = 3;
    
    private readonly Regex _categoryRegex = new(
        @"^[А-Яа-яЁёA-Za-z\s\-]+$", // Кириллица, латиница, пробелы и дефисы
        RegexOptions.Compiled);
    
    public void Validate(string categoryName)
    {
        if (string.IsNullOrWhiteSpace(categoryName))
            throw new InvalidCategoryNameException(categoryName);
        
        var trimmed = categoryName.Trim();

        if (trimmed.Length >= MinLength &&
            trimmed.Length <= MaxLength &&
            _categoryRegex.IsMatch(trimmed))
            return;
        throw new InvalidCategoryNameException(categoryName);
    }
}