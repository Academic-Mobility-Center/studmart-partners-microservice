namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;

public record UpdatePartnerRequest(    
    Guid Id,
    string Name,
    string Subtitle,
    string Description,
    int Priority,
    string Email,
    string Phone,
    long Inn,
    int CountryId,
    string Site,
    int CategoryId,
    PartnerPaymentInformationRequest PaymentInformation,
    bool HasAllRegions,
    IEnumerable<int> RegionIds);