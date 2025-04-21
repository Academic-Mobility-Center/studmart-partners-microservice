using System.Globalization;
using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class RegionsRepository(DataContext context) : EfNamedEntityRepositoryBase<Region, int, RegionName>(context), IRegionsRepository
{
    private readonly DataContext _context = context;

    public override Task<Region?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => _context.Regions
        .Include(region => region.Country).FirstOrDefaultAsync(region => region.Id == id, cancellationToken);
}