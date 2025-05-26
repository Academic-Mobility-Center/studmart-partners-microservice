using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.DescriptionRequest;

public record DescriptionRequestRejectRequest(Guid RequestId, string Comment) : IRequest;