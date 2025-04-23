using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class EmployeeFactory(IPartnersRepository partnersRepository, IEmployeesRepository employeesRepository) : IEmployeeFactory
{
    public async Task<IResult> Create(EmployeeFactoryContract contract, CancellationToken cancellationToken = default)
    {
        /* var verification = await employeesRepository.GetByEmailAsync(contract.Email, cancellationToken);
        if(verification is not null)
            return new EmailAlreadyRegisteredResult(contract.Email);*/
        var partner = await partnersRepository.GetByIdAsync(contract.PartnerId, cancellationToken);
        if(partner is null)
            return new PartnerNotFoundResult(contract.PartnerId);
        var employee = new Employee(new FirstName(contract.FirstName), new LastName(contract.LastName), new Email(contract.Email), partner);
        partner.Hire(employee);
        return new EmployeeCreatedResult(employee);
    }
}