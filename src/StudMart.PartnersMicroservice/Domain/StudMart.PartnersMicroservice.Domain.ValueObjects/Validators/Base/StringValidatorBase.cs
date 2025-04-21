using System.Text.RegularExpressions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

public abstract class StringValidatorBase<TFormatException, TLengthException, TEmptyException>(string pattern, int minLength, int maxLength) : IValidator<string> 
    where TFormatException : InvalidValueObjectValueFormatExceptionBase
    where TLengthException : InvalidLengthExceptionBase
    where TEmptyException : EmptyExceptionBase, new()
{
    public void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new TEmptyException();
        var trimmedValue = value.Trim();
        if (trimmedValue.Length < minLength || trimmedValue.Length > maxLength)
        {
            var constructor = typeof(TLengthException).GetConstructor([typeof(int)]);
            if (constructor is null)
                throw new InvalidOperationException("Can not find correct constructor");
            var exception = (TLengthException)constructor.Invoke([trimmedValue.Length]);
            throw exception;
        }

        if (!Regex.IsMatch(trimmedValue, pattern, RegexOptions.IgnoreCase))
        {
            var constructor = typeof(TFormatException).GetConstructor([typeof(string)]);
            if(constructor is null)
                throw new InvalidOperationException("Can not find correct constructor");
            var exception = (TFormatException)constructor.Invoke([trimmedValue]);
            throw exception;
        }
    }
}