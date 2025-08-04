using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record PartnerDeletionServiceModel(
    Guid PartnerId, 
    IEnumerable<Guid> EmployeesIds) : IServiceModel;