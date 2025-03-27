using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using SudMart.PartnersMicroservice.Domain.Factories.Implementations;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateRegionCommandHandlerBase(
    IRegionsRepository repository,
    IRegionFactory factory,
    IMapper mapper)
    : CreateCommandHandlerBase<CreateRegionCommand, RegionModel, RegionAddModel, Region, int, RegionFactory,
        RegionFactoryContract>(repository, factory, mapper)
{
    
}