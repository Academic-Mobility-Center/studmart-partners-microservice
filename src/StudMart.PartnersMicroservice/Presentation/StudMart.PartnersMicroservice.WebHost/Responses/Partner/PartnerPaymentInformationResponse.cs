using StudMart.PartnersMicroservice.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Partner;

public record PartnerPaymentInformationResponse(string Bik, string AccountNumber, string CorrespondentAccountNumber)
    : IResponse;
