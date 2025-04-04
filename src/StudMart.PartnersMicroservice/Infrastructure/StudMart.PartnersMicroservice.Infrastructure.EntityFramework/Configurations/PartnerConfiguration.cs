using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Configurations;

public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(partner => partner.Id);
        builder.Property(partner => partner.CompanyName).HasConversion(name => name.Name, name => new CompanyName(name))
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(partner => partner.Subtitle)
            .HasConversion(subtitle => subtitle.Value, subtitle => new Subtitle(subtitle)).HasMaxLength(35)
            .IsRequired();
        builder.Property(partner => partner.Priority)
            .HasConversion(priority => priority.Value, priority => new Priority(priority)).IsRequired();
        builder.Property(partner => partner.Inn).HasConversion(name => name.Value, name => new Inn(name)).IsRequired();
        builder.Property(partner => partner.Email).HasConversion(email => email.Value, email => new Email(email))
            .IsRequired();
        builder.Property(partner => partner.Site).HasConversion(name => name.Value, name => new Site(name))
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(partner => partner.Phone).HasConversion(name => name.Value, name => new Phone(name))
            .HasMaxLength(12)
            .IsRequired();
        builder.OwnsOne(partner => partner.PaymentInformation).Property(information => information.Bik)
            .HasConversion(bik => bik.Value, bik => new Bik(bik)).HasMaxLength(10).IsRequired();
        builder.OwnsOne(partner => partner.PaymentInformation).Property(information => information.AccountNumber)
            .HasConversion(number => number.Value, number => new AccountNumber(number)).HasMaxLength(21).IsRequired();
        builder.OwnsOne(partner => partner.PaymentInformation)
            .Property(information => information.CorrespondentAccountNumber)
            .HasConversion(number => number.Value, number => new AccountNumber(number)).HasMaxLength(21).IsRequired();
        builder.HasOne(partner => partner.Country).WithMany();
        builder.HasOne(partner => partner.Category).WithMany();
        builder.HasIndex(partner => partner.Inn).IsUnique();
        builder.HasIndex(partner => partner.Email).IsUnique();
        builder.HasIndex(partner => partner.Phone).IsUnique();
        builder.HasMany(partner => partner.Employees).WithOne(employee => employee.Partner);
    }
}