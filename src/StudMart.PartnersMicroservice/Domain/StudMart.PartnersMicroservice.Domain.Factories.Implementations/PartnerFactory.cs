using System.Text.Json;
using Microsoft.Extensions.Logging;
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
    IRegionsRepository regionsRepository,
    IPartnersRepository partnersRepository,
    ILogger<PartnerFactory> logger)
    : IPartnerFactory
{
    public async Task<IResult> Create(PartnerFactoryContract contract, CancellationToken cancellationToken = default)
    {
        var country = await countriesRepository.GetByIdAsync(contract.CountryId, cancellationToken);
        if (country is null)
        {
            logger.LogWarning("Country with Id {CContractCountryId} not found", contract.CountryId);
            return new CountryNotFoundResult(contract.CountryId);
        }
        var category = await categoriesRepository.GetByIdAsync(contract.CategoryId, cancellationToken);
        if (category is null)
        {
            logger.LogWarning("Category with {ContractCategoryId} not found", contract.CategoryId);
            return new CategoryNotFoundResult(contract.CategoryId);
        }

        var email = new Email(contract.Email);
        /*var verification = await partnersRepository.GetByEmailAsync(email, cancellationToken);
        if (verification is not null)
        {
            logger.LogWarning("Partner with email {CountractEmail} already exist", contract.Email);
            return new PartnerEmailAlreadyRegisteredResult(contract.Email);
        }*/

        var phone = new Phone(contract.Phone);
        /*verification = await partnersRepository.GetByPhoneNumberAsync(phone, cancellationToken);
        if (verification is not null)
        {
            logger.LogWarning("Partner with phone {ContractPhone} already exists", contract.Phone);
            return new PartnerPhoneAlreadyRegisteredResult(contract.Phone);
        }*/
        /*var inn = new Inn(contract.Inn);
        verification = await partnersRepository.GetByInnAsync(inn, cancellationToken);
        if (verification is not null)
        {
            logger.LogWarning("Partner with Inn {ContractInn} already exists", contract.Inn);
            return new PartnerAlreadyRegisteredResult(contract.Inn);
        }*/

        var regions = new List<Region>();
        if (!contract.HasAllRegions)
        {
            foreach (var regionId in contract.RegionIds)
            {
                var region = await regionsRepository.GetByIdAsync(regionId, cancellationToken);
                if (region is null)
                {
                    logger.LogWarning("Region with {RegionId} not found", regionId);
                    continue;
                }

                regions.Add(region);
            }
        }
        var partner = new Partner(new CompanyName(contract.Name), category, new Subtitle(contract.Subtitle),
            new Description(contract.Description),
            new Priority(contract.Priority), phone,
            email, country, new Site(contract.Site), new Inn(contract.Inn),
            new PaymentInformation(new Bik(contract.PaymentInformation.Bik),
                new AccountNumber(contract.PaymentInformation.AccountNumber),
                new AccountNumber(contract.PaymentInformation.CorrespondentAccountNumber)), contract.HasAllRegions,
            regions);
       
        return new PartnerCreatedResult(partner);
    }
}