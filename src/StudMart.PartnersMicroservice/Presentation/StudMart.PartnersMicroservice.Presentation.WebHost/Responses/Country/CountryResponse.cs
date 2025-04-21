using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Country;

public record CountryResponse(int Id, string Name, IEnumerable<RegionShortResponse> Regions) : IResponse
{
    
}