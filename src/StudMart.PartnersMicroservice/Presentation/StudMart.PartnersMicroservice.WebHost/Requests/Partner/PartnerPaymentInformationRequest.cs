using StudMart.PartnersMicroservice.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.WebHost.Requests.Partner;

public record PartnerPaymentInformationRequest(string Bik, string AccountNumber, string CorrespondentAccountNumber) : IRequest;