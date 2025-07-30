using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(employee => employee.Id);
        builder.Property(employee => employee.FirstName)
            .HasConversion(name => name.Name, name => new FirstName(name))
            .HasMaxLength(ValueObjectsLengthRules.MaxFirstNameLength)
            .IsRequired();
        builder.Property(employee => employee.LastName)
            .HasConversion(name => name.Name, name => new LastName(name))
            .HasMaxLength(ValueObjectsLengthRules.MaxLastNameLength)
            .IsRequired();
        builder.Property(employee => employee.Email)
            .HasConversion(email => email.Value, email => new Email(email))
            .HasMaxLength(ValueObjectsLengthRules.MaxEmailLength)
            .IsRequired();
        builder.HasOne(employee => employee.Partner).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}