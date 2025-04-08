using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Category;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;
using StudMart.PartnersMicroservice.WebHost.Responses.Employee;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Partner;

public record PartnerResponse(
    Guid id,
    string CompanyName,
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