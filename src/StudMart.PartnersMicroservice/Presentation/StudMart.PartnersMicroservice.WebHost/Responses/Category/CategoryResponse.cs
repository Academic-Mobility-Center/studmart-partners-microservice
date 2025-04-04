using StudMart.PartnersMicroservice.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Category;

public record CategoryResponse(int Id, string Name) : IResponse;