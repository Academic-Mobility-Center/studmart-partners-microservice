namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

public abstract class InvalidNameException(string valueObjectName, string name, string information)
    : InvalidValueObjectValueFormatExceptionBase(valueObjectName, name, information);