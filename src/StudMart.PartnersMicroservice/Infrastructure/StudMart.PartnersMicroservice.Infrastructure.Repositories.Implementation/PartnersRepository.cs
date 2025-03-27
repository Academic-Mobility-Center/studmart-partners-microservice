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

    public override Task<Partner?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => _context1.Partners
        .Include(partner => partner.Country).Include(partner => partner.Employees)
        .FirstOrDefaultAsync(partner => partner.Id == id, cancellationToken);
}