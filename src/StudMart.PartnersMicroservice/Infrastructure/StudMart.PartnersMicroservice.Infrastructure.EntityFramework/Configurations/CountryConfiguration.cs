using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(country => country.Id).IsRequired().ValueGeneratedOnAdd();
        builder.HasKey(country => country.Id);
        builder.Property(country => country.Name).IsRequired().HasMaxLength(ValueObjectsLengthRules.MaxCountryNameLength)
            .HasConversion(name => name.Name, name => new CountryName(name));
        builder.HasIndex(country => country.Name).IsUnique();
        builder.HasMany(country => country.Regions).WithOne().OnDelete(DeleteBehavior.Restrict);
      
    }
}