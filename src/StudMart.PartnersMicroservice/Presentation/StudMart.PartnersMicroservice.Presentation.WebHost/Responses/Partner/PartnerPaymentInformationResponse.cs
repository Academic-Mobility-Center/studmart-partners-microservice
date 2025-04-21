using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Partner;

public record PartnerPaymentInformationResponse(string Bik, string AccountNumber, string CorrespondentAccountNumber)
    : IResponse;
