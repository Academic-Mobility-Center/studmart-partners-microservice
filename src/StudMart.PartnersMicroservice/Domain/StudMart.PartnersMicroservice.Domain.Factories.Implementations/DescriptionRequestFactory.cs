using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.DescriptionRequest;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class DescriptionRequestFactory(
    IEmployeesRepository employeesRepository,
    ILogger<DescriptionRequestFactory> logger) : IDescriptionRequestFactory
{
    public async Task<IResult> Create(DescriptionRequestFactoryContract contract,
        CancellationToken cancellationToken = default)
    {
       var employee = await employeesRepository.GetByIdAsync(contract.EmployeeId, cancellationToken);
       if (employee is null)
       {
           logger.LogWarning("Employee with Id {ContractPartnerId} not found", contract.EmployeeId);
           return new EmployeeNotFoundResult(contract.EmployeeId);
       }

       var request = new DescriptionRequest(employee, new Description(contract.Description));
       return new DescriptionRequestCreatedResult(request);
    }
}