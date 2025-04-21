using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Region;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class RegionAddRequestValidator : AbstractValidator<RegionAddRequest>
{
    public RegionAddRequestValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("Название региона не может быть пустым");
        RuleFor(request => request.Name).NotNull().WithMessage("Название региона не может быть пустым");
        RuleFor(request => request.Name).Matches(RegexValidationRules.RegionNameValidationRegex)
            .WithMessage("Название региона может содержать только буквы и пробелы");
        RuleFor(request => request.CountyId).GreaterThan(0).WithMessage("Id страны должно быть больше 0");
        RuleFor(x => x.Name)
            .Length(ValueObjectsLengthRules.MinRegionNameLength, ValueObjectsLengthRules.MaxRegionNameLength)
            .WithMessage(
                $"Название должно быть не короче {ValueObjectsLengthRules.MinRegionNameLength}х символов и не длиннее {ValueObjectsLengthRules.MaxRegionNameLength}");
    }
}