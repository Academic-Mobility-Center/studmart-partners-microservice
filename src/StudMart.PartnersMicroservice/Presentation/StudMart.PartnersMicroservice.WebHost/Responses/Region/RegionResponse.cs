using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Region;

public record RegionResponse(int Id, string Name, CountryShortResponse Country) : IResponse;