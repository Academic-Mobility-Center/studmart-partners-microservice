using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Bik;

public class InvalidBikException(string bik) : InvalidValueObjectValueFormatExceptionBase("Bik", bik, "contains only 9 digits" )
{
    public string Bik { get; } = bik;
}