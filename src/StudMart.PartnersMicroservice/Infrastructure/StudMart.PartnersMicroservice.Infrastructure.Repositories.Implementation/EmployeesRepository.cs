using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class EmployeesRepository(DataContext context)
    : EfUpdatableDeletableRepositoryBase<Employee, Guid>(context), IEmployeesRepository
{
}