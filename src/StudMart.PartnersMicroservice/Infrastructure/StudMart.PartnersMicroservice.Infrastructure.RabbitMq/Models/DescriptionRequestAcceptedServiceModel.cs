using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record DescriptionRequestAcceptedServiceModel(Guid Id, string Email) : IServiceModel;