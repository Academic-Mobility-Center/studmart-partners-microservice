using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts;

public record PaymentInfoContract(string Bik, string AccountNumber, string CorrespondentAccountNumber)
    : IFactoryContract;

public record PartnerFactoryContract(
    string CompanyName,
    string Subtitle,
    int Priority,
    string Site,
    long Inn,
    string Email,
    string Phone,
    int CountryId,
    int CategoryId,
    PaymentInfoContract PaymentInformation,
    bool HasAllRegions,
    IEnumerable<int> RegionIds)
    : IFactoryContract;