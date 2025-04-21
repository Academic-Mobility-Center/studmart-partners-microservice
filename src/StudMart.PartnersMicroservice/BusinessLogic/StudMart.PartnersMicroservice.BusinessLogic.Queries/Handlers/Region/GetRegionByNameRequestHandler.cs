using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Region;

public class GetRegionByNameRequestHandler(IRegionsRepository repository, IMapper mapper)
    : GetByNameRequestHandlerBase<GetRegionByNameRequest, RegionModel, Domain.Entities.Region, int, RegionName>(
        repository, mapper);