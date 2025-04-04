using StudMart.PartnersMicroservice.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.WebHost.Requests.Partner;

public record PartnerAddRequest(
    string CompanyName,
    string Subtitle,
    int Priority,
    string Email,
    string Phone,
    long Inn,
    int CountryId,
    string Site,
    int CategoryId,
    PartnerPaymentInformationRequest PaymentInformation,
    bool HasAllRegions,
    IEnumerable<int> RegionIds) : IRequest;