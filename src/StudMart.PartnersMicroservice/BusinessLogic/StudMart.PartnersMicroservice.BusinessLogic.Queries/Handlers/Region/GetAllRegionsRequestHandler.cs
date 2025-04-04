using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Region;

public class GetAllRegionsRequestHandler(IRegionsRepository repository, IMapper mapper)
    : GetAllRequestHandlerBase<GetAllRegionsRequest, int, RegionModel, Domain.Entities.Region>(repository, mapper)
{
}