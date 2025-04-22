using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Region;

public record RegionQueryParameters(int? id, string? name, int? countryId)  : IQueryParameters;