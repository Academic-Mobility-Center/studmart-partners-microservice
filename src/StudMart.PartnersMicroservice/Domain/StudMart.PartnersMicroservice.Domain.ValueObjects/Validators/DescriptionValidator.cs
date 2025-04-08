using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class DescriptionValidator : IValidator<string>
{
    private const int MinLength = 600;
    private const int MaxLength = 1200;

    // Проверка на опасные символы (базовая защита)
    private static readonly Regex DangerousCharsRegex = new(
        @"[<>$\\]", // Запрещаем опасные символы
        RegexOptions.Compiled);

    public void Validate(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new EmptyDescriptionException(description);

        var trimmed = description.Trim();

        switch (trimmed.Length)
        {
            case < MinLength:
                throw new TooShortDescriptionException(description, trimmed.Length, MinLength);
            case > MaxLength:
                throw new TooLongDescriptionException(description, trimmed.Length, MaxLength);
        }

        if (DangerousCharsRegex.IsMatch(trimmed))
            throw new InvalidDescriptionException(description);
        
    }
}