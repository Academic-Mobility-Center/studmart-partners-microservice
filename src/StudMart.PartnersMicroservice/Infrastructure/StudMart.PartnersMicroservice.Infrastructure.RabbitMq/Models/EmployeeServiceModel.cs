using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

public record EmployeeServiceModel(Guid Id, string FirstName, string LastName, string Email, PartnerServiceModel Partner) : IServiceModel;
