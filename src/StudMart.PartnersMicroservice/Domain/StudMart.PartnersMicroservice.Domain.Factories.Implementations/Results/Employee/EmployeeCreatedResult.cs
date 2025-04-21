using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;

public class EmployeeCreatedResult(Entities.Employee createdEntity)
    : CreatedResultBase<Entities.Employee, Guid>(createdEntity)
{
}