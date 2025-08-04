using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
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
        .ThenInclude(partner => partner.Regions)
        .FirstOrDefaultAsync(employee => employee.Id == id, cancellationToken);

    public Task<Employee?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default) =>
        _context1.Employees
            .Include(employee => employee.Partner )
            .ThenInclude(partner => partner.Category )
            .FirstOrDefaultAsync(employee => employee.Email == email, cancellationToken);
    
    public async Task<IEnumerable<Employee>> GetAllByPartnerIdAsync(
        Guid partnerId, 
        CancellationToken cancellationToken = default)
    {
        return await _context1.Employees
            .Where(employee => employee.Partner.Id == partnerId) // Используем PartnerId вместо навигации
            .Include(employee => employee.Partner)
            .ThenInclude(partner => partner.Category)
            .AsNoTracking() // Для read-only операций
            .ToListAsync(cancellationToken);
    }

}