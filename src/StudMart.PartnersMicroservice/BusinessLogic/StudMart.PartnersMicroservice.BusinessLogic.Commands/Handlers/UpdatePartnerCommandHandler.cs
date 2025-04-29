using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class UpdatePartnerCommandHandler(
    IPartnersRepository partnersRepository,
    ICountriesRepository countriesRepository,
    IRegionsRepository regionsRepository,
    ICategoriesRepository categoriesRepository,
    IMapper mapper, ILogger<UpdatePartnerCommandHandler> logger)
    : IRequestHandler<UpdatePartnerCommand, IResult>
{
    public async Task<IResult> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var verification = await partnersRepository.GetByIdAsync(request.Model.Id, cancellationToken);
        if (verification is null)
        {
            logger.LogWarning("Partner with id {ModelId} not found", request.Model.Id);
            return new PartnerNotFoundResult(request.Model.Id);
        }

        verification = await partnersRepository.GetByInnAsync(new Inn(request.Model.Inn), cancellationToken);
        if (verification is not null && request.Model.Id != verification.Id)
        {
            logger.LogWarning("Partner with Inn {ModelInn} already exists", request.Model.Inn);
            return new PartnerAlreadyRegisteredResult(request.Model.Inn);
        }

        verification = await partnersRepository.GetByEmailAsync(new Email(request.Model.Email), cancellationToken);
        if (verification is not null && request.Model.Id != verification.Id)
        {
            logger.LogWarning("Partner with Inn {ModelEmail} already exists", request.Model.Email);
            return new PartnerEmailAlreadyRegisteredResult(request.Model.Email);
        }

        verification =
            await partnersRepository.GetByPhoneNumberAsync(new Phone(request.Model.Phone), cancellationToken);
        if (verification is not null && request.Model.Id != verification.Id)
        {
            logger.LogWarning("Partner with Phone {ModelPhone} already exists", request.Model.Phone);
            return new PartnerPhoneAlreadyRegisteredResult(request.Model.Phone);
        }

        verification = await partnersRepository.GetByNameAsync(new CompanyName(request.Model.Name), cancellationToken);
        if (verification is not null && request.Model.Id != verification.Id)
        {
            logger.LogWarning("Partner with Name {ModelName} already exists", request.Model.Name);
            return new PartnerNameAlreadyRegisteredResult(request.Model.Name);
        }
        var partner = await partnersRepository.GetByIdAsync(request.Model.Id, cancellationToken);
        logger.LogInformation(JsonSerializer.Serialize(partner));
        partner!.Name = new CompanyName(request.Model.Name);
        partner.Phone = new Phone(request.Model.Phone);
        partner.Inn = new Inn(request.Model.Inn);
        partner.Email = new Email(request.Model.Email);
        partner.HasAllRegions = request.Model.HasAllRegions;
        partner.Priority = new Priority(request.Model.Priority);
        partner.Description = new Description(request.Model.Description);
        partner.Subtitle = new Subtitle(request.Model.Subtitle);
        partner.Site = new Site(request.Model.Site);
        partner.PaymentInformation = new PaymentInformation(new Bik(request.Model.PaymentInformation.Bik),
            new AccountNumber(request.Model.PaymentInformation.AccountNumber),
            new AccountNumber(request.Model.PaymentInformation.CorrespondentAccountNumber));
        var country = await countriesRepository.GetByIdAsync(request.Model.CountryId, cancellationToken);
        if (country is null)
        {
            logger.LogWarning("Country with Id {ModelCountryId} already exists", request.Model.CountryId);
            return new CountryNotFoundResult(request.Model.CountryId);
        }

        partner.Country = country;
        var category =  await categoriesRepository.GetByIdAsync(request.Model.CategoryId, cancellationToken);
        if (category is null)
        {
            logger.LogWarning("Category with Id {ModelCategoryId} already exists", request.Model.CategoryId);
            return new CategoryNotFoundResult(request.Model.CategoryId);
        }

        partner.Category = category;
        if (!partner.HasAllRegions)
        {
            foreach (var regionId in request.Model.RegionIds)
            {
                var region = await regionsRepository.GetByIdAsync(regionId, cancellationToken);
                if (region is null)
                {
                    logger.LogWarning("Region with Id {regionId} already exists", regionId);
                    continue;
                }

                if (!partner.Regions.Contains(region))
                    partner.AddRegion(region);
            }

            foreach (var region in partner.Regions)
                if (!request.Model.RegionIds.Contains(region.Id))
                    partner.RemoveRegion(region);
        }
        var result = await partnersRepository.UpdateAsync(partner, cancellationToken);
        if (!result)
        {
            logger.LogError("Error while updating partner with id {PartnerId}", partner.Id);
            return new InternalErrorResult();
        }
        logger.LogInformation("Partner with Id {PartnerId} was updated", partner.Id);
        return new PartnerUpdatedResult(mapper.Map<PartnerModel>(partner));
    }
}