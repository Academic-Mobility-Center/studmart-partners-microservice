using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Site;

public class InvalidSiteException(string site) : InvalidValueObjectValueFormatExceptionBase("Site", site, "be in correct URL format http(s)://domain.zone/page?parameter=value....")
{
    public string Site { get; } = site;
}
