using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Subtitle;

public class InvalidLengthSubtitleException(int length) : InvalidLengthExceptionBase(ValueObjectsLengthRules.MinSubtitleLength, ValueObjectsLengthRules.MaxSubtitleLength, length, "Subtitle")
{
    
}