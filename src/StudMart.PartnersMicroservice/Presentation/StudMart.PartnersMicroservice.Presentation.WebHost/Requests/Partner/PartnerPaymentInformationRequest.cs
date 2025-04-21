using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;

public record PartnerPaymentInformationRequest(string Bik, string AccountNumber, string CorrespondentAccountNumber) : IRequest;