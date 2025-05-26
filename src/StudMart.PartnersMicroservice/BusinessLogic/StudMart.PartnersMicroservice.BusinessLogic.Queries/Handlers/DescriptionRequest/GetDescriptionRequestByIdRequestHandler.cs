using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.DescriptionRequest;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.DescriptionRequest;

public class GetDescriptionRequestByIdRequestHandler(IDescriptionRequestsRepository repository, IMapper mapper)
    : GetByIdRequestHandlerBase<GetDescriptionRequestByIdRequest, DescriptionRequestModel, Guid,
        Domain.Entities.DescriptionRequest>(repository, mapper)
{
}