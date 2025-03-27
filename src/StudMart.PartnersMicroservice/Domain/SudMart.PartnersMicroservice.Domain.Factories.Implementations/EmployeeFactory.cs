using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace SudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class EmployeeFactory(IPartnersRepository partnersRepository) : IEmployeeFactory
{
    public async Task<Employee> Create(EmployeeFactoryContract contract)
    {
        var partner = await partnersRepository.GetByIdAsync(contract.PartnerId);
        if(partner is null)
            throw new NullReferenceException("Partner not found");
        var employee = new Employee(new FirstName(contract.FirstName), new LastName(contract.LastName), new Email(contract.Email), partner);
        partner.Hire(employee);
        return employee;
    }
}