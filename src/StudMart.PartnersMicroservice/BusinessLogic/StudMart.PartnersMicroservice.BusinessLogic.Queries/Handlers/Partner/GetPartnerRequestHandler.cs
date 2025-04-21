using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Partner;

public class GetPartnerRequestHandler(IPartnersRepository repository, IMapper mapper)
    : GetByIdRequestHandlerBase<GetPartnerByIdRequest, PartnerModel, Guid, Domain.Entities.Aggregates.Partner>(repository,
        mapper)
{
}