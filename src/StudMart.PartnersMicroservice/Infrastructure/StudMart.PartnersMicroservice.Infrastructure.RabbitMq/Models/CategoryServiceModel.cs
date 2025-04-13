using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record CategoryServiceModel(int Id, string Name) : IServiceModel;
