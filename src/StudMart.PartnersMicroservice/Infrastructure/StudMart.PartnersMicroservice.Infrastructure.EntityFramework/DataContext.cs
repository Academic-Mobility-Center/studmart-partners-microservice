using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework;

public class DataContext(DbContextOptions<DbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}