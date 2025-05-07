using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Category;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class CategoryAddRequestValidator : AbstractValidator<CategoryAddRequest>
{
    public CategoryAddRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Название категории не может быть пустым");
        RuleFor(x => x.Name).NotNull().WithMessage("Название категории не может быть пустым");
        RuleFor(x => x.Name)
            .Length(ValueObjectsLengthRules.MinCategoryNameLength, ValueObjectsLengthRules.MaxCategoryNameLength)
            .WithMessage(
                $"Название должно быть не короче {ValueObjectsLengthRules.MinCategoryNameLength}х символов и не длиннее {ValueObjectsLengthRules.MaxCategoryLength}");
        RuleFor(x => x.Name).Matches(RegexValidationRules.CategoryNameValidationRegex)
            .WithMessage("Название категори может содержать только кириллицу, латиницу и пробелы");
        RuleFor(x => x.Priority).GreaterThan(0).LessThanOrEqualTo(100).WithMessage("Приоритет может принимать значения от 1 до 100");
    }
}