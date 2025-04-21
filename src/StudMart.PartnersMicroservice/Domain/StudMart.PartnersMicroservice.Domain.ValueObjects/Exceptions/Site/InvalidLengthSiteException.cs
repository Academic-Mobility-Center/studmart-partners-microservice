using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Site;

public class InvalidLengthSiteException(int length) : InvalidLengthExceptionBase(ValueObjectsLengthRules.MinSiteLength, ValueObjectsLengthRules.MaxSiteLength, length, "Site")
{
    
}