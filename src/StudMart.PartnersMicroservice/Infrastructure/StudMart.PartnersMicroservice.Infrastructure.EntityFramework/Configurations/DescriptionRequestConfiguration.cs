using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Configurations;

public class DescriptionRequestConfiguration : IEntityTypeConfiguration<DescriptionRequest>
{
    public void Configure(EntityTypeBuilder<DescriptionRequest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Description)
            .HasConversion(x=> x.Value, s => new Description(s))
            .HasMaxLength(ValueObjectsLengthRules.MaxDescriptionLength)
            .IsRequired();
        builder.HasOne(x => x.Employee).WithMany();
        builder.Navigation(x => x.Employee).AutoInclude();
    }
}