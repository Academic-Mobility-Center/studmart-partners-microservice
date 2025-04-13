using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record PartnerServiceModel(Guid Id,
    string CompanyName,
    string Subtitle,
    string Description,
    int Priority,
    string Site,
    int CategoryId,
    bool HasAllRegions,
    IEnumerable<int> RegionIds) : IServiceModel;