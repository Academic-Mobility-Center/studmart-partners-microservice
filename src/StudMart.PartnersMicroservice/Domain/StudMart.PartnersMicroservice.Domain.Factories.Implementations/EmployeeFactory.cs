using System.Text.Json;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class EmployeeFactory(IPartnersRepository partnersRepository, IEmployeesRepository employeesRepository, ILogger<EmployeeFactory> logger) : IEmployeeFactory
{
    public async Task<IResult> Create(EmployeeFactoryContract contract, CancellationToken cancellationToken = default)
    {
        var email = new Email(contract.Email);
         var verification = await employeesRepository.GetByEmailAsync(email, cancellationToken);
         if (verification is not null)
         {
             logger.LogWarning("Employee with email {EmailValue} already exists", email.Value);
             return new EmailAlreadyRegisteredResult(contract.Email);
         }

         var partner = await partnersRepository.GetByIdAsync(contract.PartnerId, cancellationToken);
         if (partner is null)
         {
             logger.LogWarning("Partner with Id {ContractPartnerId} not found", contract.PartnerId);
             return new PartnerNotFoundResult(contract.PartnerId);
         }

         var employee = new Employee(new FirstName(contract.FirstName), new LastName(contract.LastName), email, partner);
        partner.Hire(employee);
        return new EmployeeCreatedResult(employee);
    }
}