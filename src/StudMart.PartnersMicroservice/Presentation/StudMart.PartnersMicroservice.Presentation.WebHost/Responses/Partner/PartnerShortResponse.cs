using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Category;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Country;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Partner;

public record PartnerShortResponse(
    Guid Id,
    string Name,
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
