namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

public abstract class InvalidLengthExceptionBase(int minLength, int maxLength, int length, string name)
    : FormatException($"{name} length must be between {minLength} and {maxLength}. Current length is {length}")
{
    public int MinLength =>  minLength;
    public int MaxLength =>  maxLength;
    public string Name => name;
}