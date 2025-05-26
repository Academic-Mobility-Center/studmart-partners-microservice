using AutoMapper;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateDescriptionRequestCommandHandler(
    IDescriptionRequestsRepository repository,
    IDescriptionRequestFactory factory,
    IMapper mapper,
    ILogger<CreateDescriptionRequestCommandHandler> logger)
    : CreateCommandHandlerBase<CreateDescriptionRequestCommand, DescriptionRequestModel, DescriptionRequestAddModel,
        DescriptionRequest, Guid, DescriptionRequestFactory, DescriptionRequestFactoryContract,
        DescriptionRequestCreatedResult>(repository, factory, mapper, new DescriptionRequestErrorsResultProcessor(), logger)
{
}