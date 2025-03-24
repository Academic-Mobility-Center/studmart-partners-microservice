namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

public abstract class InvalidValueObjectValueFormatException(string valueObjectName, string value)
    : FormatException($"{valueObjectName} {value} is incorrect");