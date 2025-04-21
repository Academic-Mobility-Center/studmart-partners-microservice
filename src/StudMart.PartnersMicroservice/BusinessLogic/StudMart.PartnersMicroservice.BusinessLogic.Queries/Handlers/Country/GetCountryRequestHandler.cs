using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Country;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Country;

public class GetCountryRequestHandler(ICountriesRepository repository, IMapper mapper)
    : GetByIdRequestHandlerBase<GetCountryByIdRequest, CountryModel, int, Domain.Entities.Country>(repository, mapper)
{
}