using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.DescriptionRequest;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class DescriptionRequestAddRequestValidator : AbstractValidator<DescriptionRequestAddRequest>
{
    public DescriptionRequestAddRequestValidator()
    {
        RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Описание компании обязательно");
        RuleFor(x => x.Description)
            .Length(ValueObjectsLengthRules.MinDescriptionLength, ValueObjectsLengthRules.MaxDescriptionLength)
            .WithMessage(
                $"Описание компании должно быть не менее {ValueObjectsLengthRules.MinDescriptionLength} и не более {ValueObjectsLengthRules.MaxDescriptionLength}");
        RuleFor(x => x.Description).Matches(RegexValidationRules.DescriptionValidationRegex)
            .WithMessage("Описание должно содержать только буквы, цифры, пробелы, знаки препинания");
        RuleFor(x => x.EmployeeId).NotNull().NotEmpty().WithMessage("Id сотрудника обязательно");
        RuleFor(x => x.EmployeeId).NotEqual(Guid.Empty).WithMessage("Id сотрудника не должно быть пустым");
    }
}