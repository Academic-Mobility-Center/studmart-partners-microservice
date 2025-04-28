using FluentValidation;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class UpdatePartnerRequestValidator : AbstractValidator<UpdatePartnerRequest>
{
    private static bool ValidateInn(long value)
    {
        var inn = value.ToString();
        if (string.IsNullOrEmpty(inn) || inn.Length != 10)
            return false;
        int[] coefficients = [2, 4, 10, 3, 5, 9, 4, 6, 8];
        var controlSum = 0;
        for (var i = 0; i < 9; i++)
        {
            controlSum += coefficients[i] * int.Parse(inn[i].ToString());
        }

        var controlDigit = controlSum % 11;
        if (controlDigit == 10)
        {
            controlDigit = 0;
        }
        return controlDigit == int.Parse(inn[9].ToString());
    }
    public UpdatePartnerRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("Id сотрудника обязательно");
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Название компании обязательно");
        RuleFor(x => x.Name)
            .Length(ValueObjectsLengthRules.MinCompanyNameLength, ValueObjectsLengthRules.MaxCompanyNameLength)
            .WithMessage(
                $"Название компании должно быть не короче {ValueObjectsLengthRules.MinCompanyNameLength}х символов и не длиннее {ValueObjectsLengthRules.MaxCompanyNameLength}");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Id категории обязательно и не нулевое");
        RuleFor(x => x.CountryId).GreaterThan(0).WithMessage("Id страны обязательно и не нулевое");
        RuleFor(x => x.Priority).GreaterThan(0).LessThan(100).WithMessage("Приоритет должен быть от 0 до 100");
        RuleFor(x => x.Subtitle).NotNull().NotEmpty().WithMessage("Подзаголовок партнёра обязателен");
        RuleFor(x => x.Subtitle)
            .Length(ValueObjectsLengthRules.MinSubtitleLength, ValueObjectsLengthRules.MaxSubtitleLength)
            .WithMessage(
                $"Подзаголовок должен быть не короче {ValueObjectsLengthRules.MinSubtitleLength}х символов и не длинее {ValueObjectsLengthRules.MaxSubtitleLength}");
        RuleFor(x => x.Subtitle).Matches(RegexValidationRules.SubtitleValidationRegex)
            .WithMessage("Подзаголовок должен содержать только буквы и пробелы");
        RuleFor(x => x.Phone).NotNull().NotEmpty().WithMessage("Телефон обязателен");
        RuleFor(x => x.Phone).Matches(RegexValidationRules.PhoneValidationRegex)
            .WithMessage("Телефон должен быть в формате российского номера");
        RuleFor(x => x.Phone).Length(12).WithMessage("Телефон должен состоять из 12 цифр");
        RuleFor(x => x.Site).NotNull().NotEmpty().WithMessage("Сайт обязателен");
        RuleFor(x => x.Site).Matches(RegexValidationRules.SiteValidationRegex)
            .WithMessage("Сайт должен быть в формател URL");
        RuleFor(x => x.Site).Length(ValueObjectsLengthRules.MinSiteLength, ValueObjectsLengthRules.MaxSiteLength)
            .WithMessage(
                $"Сайт должен быть не менее {ValueObjectsLengthRules.MinSiteLength}х символов и не более {ValueObjectsLengthRules.MaxSiteLength}");
        RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Описание компании обязательно");
        RuleFor(x => x.Description)
            .Length(ValueObjectsLengthRules.MinDescriptionLength, ValueObjectsLengthRules.MaxDescriptionLength)
            .WithMessage(
                $"Описание компании должно быть не менее {ValueObjectsLengthRules.MinDescriptionLength} и не более {ValueObjectsLengthRules.MaxDescriptionLength}");
        RuleFor(x => x.Description).Matches(RegexValidationRules.DescriptionValidationRegex)
            .WithMessage("Описание должно содержать только буквы, цифры, пробелы, знаки препинания");
        RuleFor(x => x.PaymentInformation.Bik).NotNull().NotEmpty().WithMessage("БИК обязателен");
        RuleFor(x => x.PaymentInformation.Bik).Length(9).WithMessage("БИК должен состоять из 9 цифр");
        RuleFor(x => x.PaymentInformation.Bik).Matches(RegexValidationRules.BikValidationRegex)
            .WithMessage("БИК должен состоять из 9 цифр");
        RuleFor(x => x.PaymentInformation.AccountNumber).NotNull().NotEmpty().WithMessage("Номер счёта обязателен");
        RuleFor(x => x.PaymentInformation.AccountNumber).Length(20)
            .WithMessage("Номер счёта должен состоять из 20 цифр");
        RuleFor(x => x.PaymentInformation.AccountNumber).Matches(RegexValidationRules.AccountNumberValidationRegex)
            .WithMessage("Номер счёта должен состоять из 20 цифр");

        RuleFor(x => x.PaymentInformation.CorrespondentAccountNumber).NotNull().NotEmpty()
            .WithMessage("Номер корреспондентского счёта обязателен");
        RuleFor(x => x.PaymentInformation.CorrespondentAccountNumber).Length(20)
            .WithMessage("Номер корреспондентского счёта должен состоять из 20 цифр");
        RuleFor(x => x.PaymentInformation.CorrespondentAccountNumber)
            .Matches(RegexValidationRules.AccountNumberValidationRegex)
            .WithMessage("Номер корреспондентского счёта должен состоять из 20 цифр");

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
        RuleFor(x => x.RegionIds).NotNull().Empty().When(x => x.HasAllRegions)
            .WithMessage("Если партнёр находится по всей стране, то представленные регионы должны быть пустыми");
        RuleFor(x => x.RegionIds).NotNull().NotEmpty().When(x => !x.HasAllRegions).WithMessage(
            "Если партнёр представлен не по всей стране, то должен быть указан хотя бы 1 регион, где он пресдатвлен");
        RuleFor(x => x.Inn.ToString()).NotNull().NotEmpty().Length(9).WithMessage("ИНН должен содержать 9 цифр");
        RuleFor(x => x.Inn).Must(ValidateInn).WithMessage("ИНН не является ИНН юридического лица");
    }
}