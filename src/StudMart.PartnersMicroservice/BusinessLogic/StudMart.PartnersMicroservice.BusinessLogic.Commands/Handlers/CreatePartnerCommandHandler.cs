using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreatePartnerCommandHandler(
    IPartnersRepository repository,
    IPartnerFactory factory,
    IMapper mapper)
    : CreateCommandHandlerBase<CreatePartnerCommand, PartnerModel, PartnerAddModel, Partner, Guid, PartnerFactory,
        PartnerFactoryContract, PartnerCreatedResult>(repository, factory, mapper, new PartnerErrorsResultProcessor())
{
}