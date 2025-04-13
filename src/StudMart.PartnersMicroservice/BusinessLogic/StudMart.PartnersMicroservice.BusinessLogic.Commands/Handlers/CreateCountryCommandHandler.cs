using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;
using StudMart.PartnersMicroservice.Synchronization.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateCountryCommandHandler(
    ICountriesRepository repository,
    ICountryFactory factory,
    IMapper mapper, ISynchronizationService<CountryModel> synchronizationService)
    : CreateCommandHandlerWithNotificationBase<CreateCountryCommand, CountryModel, CountryAddModel, Country, int, CountryFactory,
        CountryFactoryContract>(
        repository, factory, mapper, synchronizationService)
{
    
}