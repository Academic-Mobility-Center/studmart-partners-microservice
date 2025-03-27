using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Country;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Country;

public class GetAllCountriesRequestHandler(ICountriesRepository repository, IMapper mapper)
    : GetAllRequestHandlerBase<GetAllCountriesRequest, int, CountryModel, Domain.Entities.Country>(repository, mapper)
{
}