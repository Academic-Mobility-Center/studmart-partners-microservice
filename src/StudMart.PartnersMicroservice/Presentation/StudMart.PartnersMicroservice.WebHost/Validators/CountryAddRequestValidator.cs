using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.WebHost.Requests.Country;

namespace StudMart.PartnersMicroservice.WebHost.Validators;

public class CountryAddRequestValidator : AbstractValidator<CountryAddRequest>
{
    public CountryAddRequestValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("Название страны не может быть пустым");
        RuleFor(request => request.Name).NotNull().WithMessage("Название страны не может быть пустым");
        RuleFor(request => request.Name).Matches(RegexValidationRules.CountryNameValidationRegex)
            .WithMessage("Название страны может содержать только буквы, пробелы и апостроф");
    }
}