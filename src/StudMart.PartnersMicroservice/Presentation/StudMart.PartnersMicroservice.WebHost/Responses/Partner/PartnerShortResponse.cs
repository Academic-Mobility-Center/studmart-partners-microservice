using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Partner;

public record PartnerShortResponse(
    Guid Id,
    string CompanyName,
    string Subtitle,
    string Priority,
    string Email,
    string Site,
    long Inn,
    string Phone,
    CountryShortResponse Country,
    PartnerPaymentInformationResponse PaymentInformation,
    bool HasAllRegions,
    IEnumerable<RegionShortResponse> Regions) : IResponse;
