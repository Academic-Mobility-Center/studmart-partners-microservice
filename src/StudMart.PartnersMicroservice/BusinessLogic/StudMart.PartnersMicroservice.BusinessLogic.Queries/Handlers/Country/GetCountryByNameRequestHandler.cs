using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Country;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Country;

public class GetCountryByNameRequestHandler(ICountriesRepository repository, IMapper mapper)
    : GetByNameRequestHandlerBase<GetCountryByNameRequest, CountryModel, Domain.Entities.Country, int, CountryName>(
        repository, mapper);