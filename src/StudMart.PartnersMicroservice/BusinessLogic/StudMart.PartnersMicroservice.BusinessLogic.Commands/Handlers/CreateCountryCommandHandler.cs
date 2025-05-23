using AutoMapper;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateCountryCommandHandler(
    ICountriesRepository repository,
    ICountryFactory factory,
    IMapper mapper, ILogger<CreateCountryCommandHandler> logger)
    : CreateCommandHandlerBase<CreateCountryCommand, CountryModel, CountryAddModel, Country, int, CountryFactory,
        CountryFactoryContract, CountryCreatedResult>(
        repository, factory, mapper, new CountryErrorsResultProcessor(), logger)
{
    
}