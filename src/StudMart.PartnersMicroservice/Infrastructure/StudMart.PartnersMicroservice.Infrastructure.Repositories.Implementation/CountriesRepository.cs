using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class CountriesRepository(DataContext context) : EfNamedEntityRepositoryBase<Country, int, CountryName>(context), ICountriesRepository, IAsyncDisposable
{
    private readonly DataContext _context = context;

    public override Task<Country?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => _context
        .Countries.Include(country => country.Regions)
        .FirstOrDefaultAsync(country => country.Id == id, cancellationToken);
}