using StudMart.PartnersMicroservice.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.WebHost.Requests.Category;

public record CategoryAddRequest(string Name) : IRequest;