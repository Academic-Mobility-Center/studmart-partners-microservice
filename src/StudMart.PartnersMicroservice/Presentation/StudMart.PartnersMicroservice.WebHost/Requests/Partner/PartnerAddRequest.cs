using StudMart.PartnersMicroservice.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.WebHost.Requests.Partner;

public record PartnerAddRequest(string CompanyName, string Email, string Phone, long Inn, int CountryId, string Site, PartnerPaymentInformationRequest PaymentInformation) : IRequest;