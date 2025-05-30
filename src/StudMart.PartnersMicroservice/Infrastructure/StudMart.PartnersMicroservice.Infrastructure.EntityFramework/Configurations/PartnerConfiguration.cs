using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Configurations;

public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(partner => partner.Id);
        builder.Property(partner => partner.Name)
            .HasConversion(name => name.Name, name => new CompanyName(name))
            .HasMaxLength(ValueObjectsLengthRules.MaxCompanyNameLength)
            .IsRequired();
        builder.Property(partner => partner.Subtitle)
            .HasConversion(subtitle => subtitle.Value, subtitle => new Subtitle(subtitle))
            .HasMaxLength(ValueObjectsLengthRules.MaxSubtitleLength)
            .IsRequired();
        builder.Property(partner => partner.Description)
            .HasConversion(description => description.Value, description => new Description(description))
            .HasMaxLength(ValueObjectsLengthRules.MaxDescriptionLength)
            .IsRequired();
        builder.Property(partner => partner.Priority)
            .HasConversion(priority => priority.Value, priority => new Priority(priority))
            .IsRequired();
        builder.Property(partner => partner.Inn)
            .HasConversion(name => name.Value, name => new Inn(name))
            .IsRequired();
        builder.Property(partner => partner.Email)
            .HasConversion(email => email.Value, email => new Email(email))
            .HasMaxLength(ValueObjectsLengthRules.MaxEmailLength)
            .IsRequired();
        builder.Property(partner => partner.Site)
            .HasConversion(name => name.Value, name => new Site(name))
            .HasMaxLength(ValueObjectsLengthRules.MaxSiteLength)
            .IsRequired();
        builder.Property(partner => partner.Phone)
            .HasConversion(name => name.Value, name => new Phone(name))
            .HasMaxLength(ValueObjectsLengthRules.MaxPhoneNumberLength)
            .IsRequired();
        builder.OwnsOne(partner => partner.PaymentInformation)
            .Property(information => information.Bik)
            .HasConversion(bik => bik.Value, bik => new Bik(bik))
            .HasMaxLength(ValueObjectsLengthRules.MaxBikLength)
            .IsRequired();
        builder.OwnsOne(partner => partner.PaymentInformation)
            .Property(information => information.AccountNumber)
            .HasConversion(number => number.Value, number => new AccountNumber(number)).
            HasMaxLength(ValueObjectsLengthRules.MaxAccountNumberLength)
            .IsRequired();
        builder.OwnsOne(partner => partner.PaymentInformation)
            .Property(information => information.CorrespondentAccountNumber)
            .HasConversion(number => number.Value, number => new AccountNumber(number))
            .HasMaxLength(ValueObjectsLengthRules.MaxAccountNumberLength)
            .IsRequired();
        builder.HasOne(partner => partner.Country).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(partner => partner.Category).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(partner => partner.Name).IsUnique();
        /*builder.HasIndex(partner => partner.Inn).IsUnique();
        builder.HasIndex(partner => partner.Email).IsUnique();
        builder.HasIndex(partner => partner.Phone).IsUnique();*/
        builder.HasMany(partner => partner.Employees).WithOne(employee => employee.Partner).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(partner => partner.Regions).WithMany();
        builder.Navigation(partner => partner.Category).AutoInclude();
        builder.Navigation(partner => partner.Country).AutoInclude();
        builder.Navigation(partner => partner.Regions).AutoInclude();
    }
}