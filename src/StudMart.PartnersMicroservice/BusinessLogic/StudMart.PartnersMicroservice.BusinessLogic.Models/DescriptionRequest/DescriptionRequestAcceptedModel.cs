using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;

public record DescriptionRequestAcceptedModel(Guid Id, string Email) : IModel;