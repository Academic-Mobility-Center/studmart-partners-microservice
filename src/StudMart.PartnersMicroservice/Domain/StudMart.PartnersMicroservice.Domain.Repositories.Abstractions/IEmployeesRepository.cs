using StudMart.PartnersMicroservice.Domain.Entities;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IEmployeesRepository : IUpdatableRepository<Employee, Guid>, IDeletableRepository<Employee, Guid>,
    IEmailEntityRepository<Employee, Guid>

{
}