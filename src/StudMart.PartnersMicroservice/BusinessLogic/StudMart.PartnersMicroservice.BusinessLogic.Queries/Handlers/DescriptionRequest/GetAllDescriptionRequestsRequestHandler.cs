using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.DescriptionRequest;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.DescriptionRequest;

public class GetAllDescriptionRequestsRequestHandler(IDescriptionRequestsRepository repository, IMapper mapper)
    : GetAllRequestHandlerBase<GetAllDescriptionRequestsRequest, Guid, DescriptionRequestModel,
        Domain.Entities.DescriptionRequest>(repository, mapper)
{
}