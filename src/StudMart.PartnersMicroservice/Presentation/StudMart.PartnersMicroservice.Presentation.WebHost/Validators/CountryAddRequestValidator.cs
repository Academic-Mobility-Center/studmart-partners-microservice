using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Country;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class CountryAddRequestValidator : AbstractValidator<CountryAddRequest>
{
    public CountryAddRequestValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("Название страны не может быть пустым");
        RuleFor(request => request.Name).NotNull().WithMessage("Название страны не может быть пустым");
        RuleFor(request => request.Name).Matches(RegexValidationRules.CountryNameValidationRegex)
            .WithMessage("Название страны может содержать только буквы, пробелы и апостроф");
        RuleFor(x => x.Name)
            .Length(ValueObjectsLengthRules.MinCountryNameLength, ValueObjectsLengthRules.MaxCountryNameLength)
            .WithMessage(
                $"Название должно быть не короче {ValueObjectsLengthRules.MinCountryNameLength}х символов и не длиннее {ValueObjectsLengthRules.MaxCountryNameLength}");
    }
}