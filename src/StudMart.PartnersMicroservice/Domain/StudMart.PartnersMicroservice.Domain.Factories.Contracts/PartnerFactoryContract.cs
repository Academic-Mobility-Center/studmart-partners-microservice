using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts;

public record PaymentInfoContract(string Bik, string AccountNumber, string CorrespondentAccountNumber)
    : IFactoryContract;

public record PartnerFactoryContract(
    string CompanyName,
    string Site,
    long Inn,
    string Email,
    string Phone,
    int CountryId,
    PaymentInfoContract PaymentInformation)
    : IFactoryContract;