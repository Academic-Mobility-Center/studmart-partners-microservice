using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;

public class GetRegionsByCountryRequest(int countryId) : IRequest<IEnumerable<RegionModel>?>
{
    public int CountryId => countryId;
}