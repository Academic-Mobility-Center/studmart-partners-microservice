using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CountryName;

public class InvalidLengthCountryNameException(int length) : InvalidLengthExceptionBase(ValueObjectsLengthRules.MinCountryNameLength, ValueObjectsLengthRules.MaxCountryNameLength, length, "Country name")
{
    
}