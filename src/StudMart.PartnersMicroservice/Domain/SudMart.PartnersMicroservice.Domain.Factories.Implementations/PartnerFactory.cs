using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace SudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class PartnerFactory(ICountriesRepository countriesRepository) : IPartnerFactory
{
    public async Task<Partner> Create(PartnerFactoryContract contract)
    {
        var country = await countriesRepository.GetByIdAsync(contract.CountryId);
        if (country is null)
            throw new NullReferenceException("Country not found");

        var partner = new Partner(new CompanyName(contract.CompanyName), new Phone(contract.Phone),
            new Email(contract.Email), country, new Site(contract.Site), new Inn(contract.Inn),
            new PaymentInformation(new Bik(contract.PaymentInformation.Bik),
                new AccountNumber(contract.PaymentInformation.AccountNumber),
                new AccountNumber(contract.PaymentInformation.CorrespondentAccountNumber)));
        return partner;
    }
}