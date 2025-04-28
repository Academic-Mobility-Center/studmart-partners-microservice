using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;

namespace StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

public class ChangeRegionForAllCountryPartnerException(Partner partner) : InvalidOperationException($"Can not change regions for all country partner Id {partner.Id}")
{
    public Partner Partner => partner;
}