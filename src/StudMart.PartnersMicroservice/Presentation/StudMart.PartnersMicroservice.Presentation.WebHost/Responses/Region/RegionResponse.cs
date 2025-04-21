using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Region;

public record RegionResponse(int Id, string Name, CountryShortResponse Country) : IResponse;