using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class EmployeesRepository(DataContext context)
    : EfUpdatableDeletableRepositoryBase<Employee, Guid>(context), IEmployeesRepository
{
    private readonly DataContext _context1 = context;

    public override Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => _context1
        .Employees.Include(employee => employee.Partner)
        .FirstOrDefaultAsync(employee => employee.Id == id, cancellationToken);
}