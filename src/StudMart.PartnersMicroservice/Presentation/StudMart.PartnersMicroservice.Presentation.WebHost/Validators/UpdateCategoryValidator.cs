using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Category;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0).WithMessage("Id категории обязательно");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Название категории не может быть пустым");
        RuleFor(x => x.Name).NotNull().WithMessage("Название категории не может быть пустым");
        RuleFor(x => x.Name)
            .Length(ValueObjectsLengthRules.MinCategoryNameLength, ValueObjectsLengthRules.MaxCategoryNameLength)
            .WithMessage(
                $"Название должно быть не короче {ValueObjectsLengthRules.MinCategoryNameLength}х символов и не длиннее {ValueObjectsLengthRules.MaxCategoryLength}");
        RuleFor(x => x.Name).Matches(RegexValidationRules.CategoryNameValidationRegex)
            .WithMessage("Название категори может содержать только кириллицу, латиницу и пробелы");
    }
}