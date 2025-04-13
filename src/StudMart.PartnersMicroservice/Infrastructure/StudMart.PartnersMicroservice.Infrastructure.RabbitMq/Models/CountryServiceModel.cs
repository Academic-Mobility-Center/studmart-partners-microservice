using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record CountryServiceModel(int Id, string Name) : IServiceModel;
