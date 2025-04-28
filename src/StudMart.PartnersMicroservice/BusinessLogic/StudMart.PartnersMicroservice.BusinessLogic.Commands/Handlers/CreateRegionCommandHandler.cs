using AutoMapper;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateRegionCommandHandler(
    IRegionsRepository repository,
    IRegionFactory factory,
    IMapper mapper, ILogger<CreateRegionCommandHandler> logger)
    : CreateCommandHandlerBase<CreateRegionCommand, RegionModel, RegionAddModel, Region, int, RegionFactory,
        RegionFactoryContract, RegionCreatedResult>(repository, factory, mapper, new RegionErrorsResultProcessor(), logger)
{
    
}