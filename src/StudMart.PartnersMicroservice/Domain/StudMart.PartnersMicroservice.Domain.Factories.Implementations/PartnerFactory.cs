using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class PartnerFactory(ICountriesRepository countriesRepository, ICategoriesRepository categoriesRepository)
    : IPartnerFactory
{
    public async Task<Partner> Create(PartnerFactoryContract contract)
    {
        var country = await countriesRepository.GetByIdAsync(contract.CountryId);
        if (country is null)
            throw new NullReferenceException("Country not found");
        var category = await categoriesRepository.GetByIdAsync(contract.CategoryId);
        if (category is null)
            throw new NullReferenceException("Category not found");

        var partner = new Partner(new CompanyName(contract.CompanyName), category, new Subtitle(contract.Subtitle),
            new Priority(contract.Priority), new Phone(contract.Phone),
            new Email(contract.Email), country, new Site(contract.Site), new Inn(contract.Inn),
            new PaymentInformation(new Bik(contract.PaymentInformation.Bik),
                new AccountNumber(contract.PaymentInformation.AccountNumber),
                new AccountNumber(contract.PaymentInformation.CorrespondentAccountNumber)));
        return partner;
    }
}