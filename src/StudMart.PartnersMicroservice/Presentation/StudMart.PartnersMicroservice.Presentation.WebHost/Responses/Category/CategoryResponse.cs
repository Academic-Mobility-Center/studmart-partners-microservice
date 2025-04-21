using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Category;

public record CategoryResponse(int Id, string Name) : IResponse;