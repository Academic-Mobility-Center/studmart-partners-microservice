using FluentValidation;
using FluentValidation.Validators;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Validators;

public class InnValidator : AbstractValidator<long>
{
    private static bool ValidateInn(long value)
    {
        var inn = value.ToString();
    
        // Проверка длины ИНН
        if (string.IsNullOrEmpty(inn) || (inn.Length != 10 && inn.Length != 12))
            return false;

        switch (inn.Length)
        {
            // Проверка 10-значного ИНН (для юр. лиц)
            case 10:
            {
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

                if (controlDigit != int.Parse(inn[9].ToString()))
                    return false;
                break;
            }
            // Проверка 12-значного ИНН (для физ. лиц и ИП)
            case 12:
            {
                // Проверка первой контрольной цифры
                int[] coefficients1 = [7, 2, 4, 10, 3, 5, 9, 4, 6, 8];
                var controlSum1 = 0;
                for (var i = 0; i < 10; i++)
                {
                    controlSum1 += coefficients1[i] * int.Parse(inn[i].ToString());
                }

                var controlDigit1 = controlSum1 % 11;
                if (controlDigit1 == 10)
                {
                    controlDigit1 = 0;
                }

                // Проверка второй контрольной цифры
                int[] coefficients2 = [3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8];
                var controlSum2 = 0;
                for (var i = 0; i < 11; i++)
                {
                    controlSum2 += coefficients2[i] * int.Parse(inn[i].ToString());
                }

                var controlDigit2 = controlSum2 % 11;
                if (controlDigit2 == 10)
                {
                    controlDigit2 = 0;
                }

                if (controlDigit1 != int.Parse(inn[10].ToString()) || 
                    controlDigit2 != int.Parse(inn[11].ToString()))
                {
                    return false;
                }

                break;
            }
        }

        return true;

    }

    public InnValidator()
    {
        RuleFor(x => ValidateInn(x)).Equal(false).WithMessage("Число не является ИНН юридического лица");
    }
    
}