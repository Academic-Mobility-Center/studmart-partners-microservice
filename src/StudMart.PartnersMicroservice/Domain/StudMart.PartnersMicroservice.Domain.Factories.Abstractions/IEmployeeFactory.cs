using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions;

public interface IEmployeeFactory : IEntityFactory<Employee, Guid, EmployeeFactoryContract>
{
    
}