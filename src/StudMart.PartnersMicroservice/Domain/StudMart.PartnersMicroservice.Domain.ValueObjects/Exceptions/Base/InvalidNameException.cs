namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

public abstract class InvalidNameException(string valueObjectName, string name) : InvalidValueObjectValueFormatException(valueObjectName, $"'{name}'")
{
    public string Name { get; } = name;
}