using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Category;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Country;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Partner;

public record PartnerResponse(
    Guid id,
    string Name,
    string Subtitle,
    string Description,
    int Priority,
    string Email,
    string Site,
    long Inn,
    string Phone,
    CountryShortResponse Country,
    CategoryResponse Category,
    PartnerPaymentInformationResponse PaymentInformation,
    IEnumerable<EmployeeShortResponse> Employees,
    bool HasAllRegions,
    IEnumerable<RegionResponse> Regions) : IResponse;