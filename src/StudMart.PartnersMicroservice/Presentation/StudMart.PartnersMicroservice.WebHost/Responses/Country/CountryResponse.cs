using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Country;

public record CountryResponse(int Id, string Name, IEnumerable<RegionShortResponse> Regions) : IResponse
{
    
}