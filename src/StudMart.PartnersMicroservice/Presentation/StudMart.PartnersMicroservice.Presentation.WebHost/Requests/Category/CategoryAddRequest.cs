using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Category;

public record CategoryAddRequest(string Name) : IRequest;