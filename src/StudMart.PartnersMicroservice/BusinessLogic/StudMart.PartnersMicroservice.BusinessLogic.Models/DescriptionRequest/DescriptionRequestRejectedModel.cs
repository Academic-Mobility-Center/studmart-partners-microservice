using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;

public record DescriptionRequestRejectedModel(Guid Id, string Email, string Comment) : IModel;