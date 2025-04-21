using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).ValueGeneratedOnAdd().IsRequired();
        builder.Property(category => category.Name).HasMaxLength(ValueObjectsLengthRules.MaxCategoryNameLength)
            .HasConversion(name => name.Name, name => new CategoryName(name)).IsRequired();
        builder.HasIndex(category => category.Name).IsUnique();
    }
}