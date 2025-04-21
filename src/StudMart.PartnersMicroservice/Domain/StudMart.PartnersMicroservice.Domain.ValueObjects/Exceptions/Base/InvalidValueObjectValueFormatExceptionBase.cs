namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

public abstract class InvalidValueObjectValueFormatExceptionBase(
    string valueObjectName,
    string value,
    string information)
    : FormatException($"{valueObjectName} '{value}' is incorrect. {valueObjectName} must {information}.")
{
    public string Value => value;
}