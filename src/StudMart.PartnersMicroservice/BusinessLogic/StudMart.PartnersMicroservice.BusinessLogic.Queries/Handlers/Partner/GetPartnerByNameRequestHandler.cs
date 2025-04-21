using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Partner;

public class GetPartnerByNameRequestHandler(IPartnersRepository repository, IMapper mapper)
    : GetByNameRequestHandlerBase<GetPartnerByNameRequest, PartnerModel, Domain.Entities.Aggregates.Partner, Guid,
        CompanyName>(repository, mapper);