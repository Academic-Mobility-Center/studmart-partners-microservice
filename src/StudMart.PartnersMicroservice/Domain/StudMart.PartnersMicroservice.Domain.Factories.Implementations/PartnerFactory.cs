using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Region;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class PartnerFactory(
    ICountriesRepository countriesRepository,
    ICategoriesRepository categoriesRepository,
    IRegionsRepository regionsRepository)
    : IPartnerFactory
{
    public async Task<IResult> Create(PartnerFactoryContract contract, CancellationToken cancellationToken = default)
    {
        var country = await countriesRepository.GetByIdAsync(contract.CountryId, cancellationToken);
        if (country is null)
            return new CountryNotFoundResult(contract.CountryId);
        var category = await categoriesRepository.GetByIdAsync(contract.CategoryId, cancellationToken);
        if (category is null)
            return new CategoryNotFoundResult(contract.CategoryId);
        var regions = new List<Region>();
        if (!contract.HasAllRegions)
        {
            foreach (var regionId in contract.RegionIds)
            {
                var region = await regionsRepository.GetByIdAsync(regionId, cancellationToken);
                if (region is null)
                    continue;
                regions.Add(region);
            }
        }

        var partner = new Partner(new CompanyName(contract.Name), category, new Subtitle(contract.Subtitle),
            new Description(contract.Description),
            new Priority(contract.Priority), new Phone(contract.Phone),
            new Email(contract.Email), country, new Site(contract.Site), new Inn(contract.Inn),
            new PaymentInformation(new Bik(contract.PaymentInformation.Bik),
                new AccountNumber(contract.PaymentInformation.AccountNumber),
                new AccountNumber(contract.PaymentInformation.CorrespondentAccountNumber)), contract.HasAllRegions,
            regions);
        return new PartnerCreatedResult(partner);
    }
}