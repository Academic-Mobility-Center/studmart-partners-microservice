using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;
using StudMart.PartnersMicroservice.WebHost.Responses.Employee;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Partner;

public record PartnerResponse(
    Guid id,
    string CompanyName,
    string Email,
    string Site,
    long Inn,
    CountryShortResponse Country,
    PartnerPaymentInformationResponse PaymentInformation,
    IEnumerable<EmployeeShortResponse> Employees) : IResponse;