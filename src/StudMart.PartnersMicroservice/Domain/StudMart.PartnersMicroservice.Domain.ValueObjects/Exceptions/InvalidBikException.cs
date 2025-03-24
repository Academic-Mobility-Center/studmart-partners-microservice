using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidBikException(string bik) : InvalidValueObjectValueFormatException("Bik", bik.ToString())
{
    public string Bik { get; } = bik;
}