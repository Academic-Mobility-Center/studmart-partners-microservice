using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Partner;

public record PartnerShortResponse(
    Guid Id,
    string CompanyName,
    string Email,
    string Site,
    long Inn,
    CountryShortResponse Country,
    PartnerPaymentInformationResponse PaymentInformation) : IResponse;
