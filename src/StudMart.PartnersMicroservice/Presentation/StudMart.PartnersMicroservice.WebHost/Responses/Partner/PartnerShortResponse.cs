using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;

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
    PartnerPaymentInformationResponse PaymentInformation) : IResponse;
