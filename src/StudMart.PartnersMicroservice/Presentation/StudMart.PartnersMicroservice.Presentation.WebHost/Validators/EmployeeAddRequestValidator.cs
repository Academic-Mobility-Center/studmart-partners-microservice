using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Employee;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class EmployeeAddRequestValidator : AbstractValidator<EmployeeAddRequest>
{
    public EmployeeAddRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .Matches(RegexValidationRules.EmailValidationRegex)
            .WithMessage("Email должен удовлетворять формату и не быть пустым");
        RuleFor(x => x.Email)
            .Length(ValueObjectsLengthRules.MinEmailLength, ValueObjectsLengthRules.MaxEmailLength)
            .WithMessage(
                $"Email должен быть не короче {ValueObjectsLengthRules.MinEmailLength}х символов и не длиннее {ValueObjectsLengthRules.MaxEmailLength}");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Имя не может быть пустым");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Фамилия не может быть пустой");
        RuleFor(x => x.FirstName)
            .Length(ValueObjectsLengthRules.MinFirstNameLength, ValueObjectsLengthRules.MaxFirstNameLength)
            .WithMessage(
                $"Имя должно быть не короче {ValueObjectsLengthRules.MinFirstNameLength}х символов и не длиннее {ValueObjectsLengthRules.MaxFirstNameLength}");
        RuleFor(x => x.LastName)
            .Length(ValueObjectsLengthRules.MinLastNameLength, ValueObjectsLengthRules.MaxLastNameLength)
            .WithMessage(
                $"Название должно быть не короче {ValueObjectsLengthRules.MinLastNameLength}х символов и не длиннее {ValueObjectsLengthRules.MaxLastNameLength}");
        RuleFor(x => x.FirstName).Matches(RegexValidationRules.NamePartValidationRegex)
            .WithMessage("Имя должно содержать только русские буквы");
        RuleFor(x => x.LastName).Matches(RegexValidationRules.NamePartValidationRegex)
            .WithMessage("Фамилия должна содержать только русские буквы");
    }
}