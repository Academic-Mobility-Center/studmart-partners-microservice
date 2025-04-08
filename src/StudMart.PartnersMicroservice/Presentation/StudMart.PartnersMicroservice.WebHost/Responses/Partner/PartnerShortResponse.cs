using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Category;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Partner;

public record PartnerShortResponse(
    Guid Id,
    string CompanyName,
    string Subtitle,
    string Description,
    int Priority,
    string Email,
    string Site,
    long Inn,
    string Phone,
    CategoryResponse Category,
    CountryShortResponse Country,
    PartnerPaymentInformationResponse PaymentInformation,
    bool HasAllRegions,
    IEnumerable<RegionShortResponse> Regions) : IResponse;
