using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Region;

public class GetRegionRequestHandler(IRegionsRepository repository, IMapper mapper)
    : GetByIdRequestHandlerBase<GetRegionByIdRequest, RegionModel, int, Domain.Entities.Region>(repository, mapper)
{
}