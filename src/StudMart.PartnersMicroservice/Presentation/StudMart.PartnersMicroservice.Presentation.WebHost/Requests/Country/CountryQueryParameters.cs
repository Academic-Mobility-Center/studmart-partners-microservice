using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Country;

public record CountryQueryParameters(int? id, string? name) : IQueryParameters;