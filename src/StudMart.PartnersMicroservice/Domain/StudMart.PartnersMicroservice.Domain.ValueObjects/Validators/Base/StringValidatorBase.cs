using System.Text.RegularExpressions;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

public abstract class StringValidatorBase<TException>(string pattern) : IValidator<string> where TException : Exception
{
    public void Validate(string value)
    {
        var constructor = typeof(TException).GetConstructor([typeof(string)]);
        if (constructor == null)
            throw new InvalidOperationException("Can not find exception constructor");
        if (constructor.Invoke([value]) is not TException exception)
            throw new InvalidOperationException("Exception object is null");

        if (string.IsNullOrEmpty(value) || value.Count(c => c == ' ') == value.Length
                                        || !Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
            throw exception;
    }
}