using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class PartnersRepository(DataContext context)
    : EfUpdatableDeletableRepositoryBase<Partner, Guid>(context), IPartnersRepository
{
    private readonly DataContext _context1 = context;

    public override Task<IEnumerable<Partner>> GetAllAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(_context1.Partners
            .Include(partner => partner.Country)
            .Include(partner => partner.Category)
            .Include(partner => partner.Regions)
            .ToList().AsEnumerable());


    public override Task<Partner?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => _context1
        .Partners
        .Include(partner => partner.Category)
        .Include(partner => partner.Country)
        .Include(partner => partner.Employees)
        .Include(partner => partner.Regions)
        .FirstOrDefaultAsync(partner => partner.Id == id, cancellationToken);
}