using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Bik;

public class InvalidLengthBikException(int length) : InvalidLengthExceptionBase(ValueObjectsLengthRules.MinBikLength, ValueObjectsLengthRules.MaxBikLength, length, "Bik")
{
    
}