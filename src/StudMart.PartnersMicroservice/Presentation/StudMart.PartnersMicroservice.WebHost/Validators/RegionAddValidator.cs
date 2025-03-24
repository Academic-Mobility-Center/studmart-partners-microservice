using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.WebHost.Requests.Region;

namespace StudMart.PartnersMicroservice.WebHost.Validators;

public class RegionAddValidator : AbstractValidator<RegionAddRequest>
{
    public RegionAddValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("Название региона не может быть пустым");
        RuleFor(request => request.Name).NotNull().WithMessage("Название региона не может быть пустым");
        RuleFor(request => request.Name).Matches(RegexValidationRules.RegionNameValidationRegex)
            .WithMessage("Название региона может содержать только буквы и пробелы");
        RuleFor(request => request.CountyId).GreaterThan(0).WithMessage("Id страны должно быть больше 0");
    }
}