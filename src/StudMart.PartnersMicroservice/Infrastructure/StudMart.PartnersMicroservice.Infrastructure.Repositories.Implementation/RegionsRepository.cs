using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class RegionsRepository(DataContext context) : EfRepositoryBase<Region, int>(context), IRegionsRepository
{
    public override Task<Region?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => context.Regions
        .Include(region => region.Country).FirstOrDefaultAsync(region => region.Id == id, cancellationToken);
}