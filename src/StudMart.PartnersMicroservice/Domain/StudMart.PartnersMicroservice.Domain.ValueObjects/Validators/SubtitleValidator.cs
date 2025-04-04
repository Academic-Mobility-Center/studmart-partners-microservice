using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class SubtitleValidator : IValidator<string>
{
    private const int MaxLength = 35;
    private static readonly Regex SubtitleRegex = new Regex(
        @"^[А-Яа-яЁёA-Za-z\s\-,]+$", // Кириллица, латиница, пробелы, дефисы и запятые
        RegexOptions.Compiled);
    
    public void Validate(string subtitle)
    {
        if (string.IsNullOrWhiteSpace(subtitle))
            throw new InvalidSubtitleException(subtitle);
        
        var trimmed = subtitle.Trim();
        
        if(trimmed.Length <= MaxLength && 
               SubtitleRegex.IsMatch(trimmed) &&
               trimmed.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries).Length >= 2)
            return;
        throw new InvalidSubtitleException(subtitle);
    }
}