using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidSiteException(string site) : InvalidValueObjectValueFormatException("Site", site)
{
    public string Site { get; } = site;
}
