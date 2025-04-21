using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Configurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.Property(region => region.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.HasKey(region => region.Id);
        builder.Property(region => region.Name)
            .IsRequired()
            .HasMaxLength(ValueObjectsLengthRules.MaxRegionNameLength)
            .HasConversion(name => name.Value, name => new RegionName(name));
        builder.HasIndex(region => region.Name).IsUnique();
        builder.HasOne<Country>(region => region.Country).WithMany().OnDelete(DeleteBehavior.Restrict);
    }
}