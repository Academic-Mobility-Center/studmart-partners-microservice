using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record DescriptionRequestRejectedServiceModel(Guid Id, string Email, string Comment) : IServiceModel;