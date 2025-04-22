using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Region;

public class GetRegionsByCountryRequestHandler(IRegionsRepository regionsRepository, ICountriesRepository countriesRepository, IMapper mapper) : IRequestHandler<GetRegionsByCountryRequest, IEnumerable<RegionModel>?>
{
    public async Task<IEnumerable<RegionModel>?> Handle(GetRegionsByCountryRequest request, CancellationToken cancellationToken)
    {
        var country = await countriesRepository.GetByIdAsync(request.CountryId, cancellationToken);
        if (country is null)
            return null;
        var regions = await regionsRepository.GetAllRegionsByCountryAsync(country, cancellationToken);
        return regions.Select(mapper.Map<RegionModel>);
    }
}