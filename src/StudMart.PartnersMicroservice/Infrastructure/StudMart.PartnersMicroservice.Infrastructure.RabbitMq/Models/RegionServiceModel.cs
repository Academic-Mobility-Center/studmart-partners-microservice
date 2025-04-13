using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record RegionServiceModel(int Id, string Name, int CountryId) : IServiceModel;
