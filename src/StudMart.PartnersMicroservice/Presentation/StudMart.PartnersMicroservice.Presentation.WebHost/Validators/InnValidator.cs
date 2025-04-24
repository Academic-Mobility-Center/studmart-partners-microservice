using FluentValidation;
using FluentValidation.Validators;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class InnValidator : AbstractValidator<long>
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

    public InnValidator()
    {
        RuleFor(x => ValidateInn(x)).Equal(false).WithMessage("Число не является ИНН юридического лица");
    }
    
}