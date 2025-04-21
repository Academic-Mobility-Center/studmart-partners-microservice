using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Inn;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

/// <summary>
/// Class that helps validate INN of organization inn
/// </summary>
public class InnValidator : IValidator<long>
{
    /// <summary>
    /// Method that validates INN of company
    /// </summary>
    /// <param name="value">Numeric inn that represents INN of company</param>
    public void Validate(long value)
    {
        var inn = value.ToString();
        if (string.IsNullOrEmpty(inn) || inn.Length != 10)
            throw new InvalidInnException(value);
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
            throw new InvalidInnException(value);
    }
}