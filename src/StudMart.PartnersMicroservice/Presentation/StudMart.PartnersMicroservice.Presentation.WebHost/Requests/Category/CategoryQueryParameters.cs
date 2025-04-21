using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Category;

public record CategoryQueryParameters(int? id, string? name) : IQueryParameters;