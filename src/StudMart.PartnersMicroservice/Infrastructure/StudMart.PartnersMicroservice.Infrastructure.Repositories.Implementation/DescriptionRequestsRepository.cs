using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Entities.Enums;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class DescriptionRequestsRepository(DataContext context) : EfUpdatableDeletableRepositoryBase<DescriptionRequest, Guid>(context), IDescriptionRequestsRepository
{
    private readonly DataContext _context = context;

    public override Task<IEnumerable<DescriptionRequest>> GetAllAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(_context.DescriptionRequests
            .Include(r => r.Employee)
            .ThenInclude(e => e.Partner)
            .Where(d => d.State == DescriptionRequestState.UnderVerification)
            .ToList().AsEnumerable());
    public override Task<DescriptionRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => _context
        .DescriptionRequests
        .Include(d => d.Employee)
        .ThenInclude(e => e.Partner)
        .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
}   