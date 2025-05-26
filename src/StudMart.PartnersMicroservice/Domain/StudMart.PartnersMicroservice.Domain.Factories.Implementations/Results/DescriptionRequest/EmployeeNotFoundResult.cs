using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.DescriptionRequest;

public class EmployeeNotFoundResult(Guid id) : NotFoundResultBase<Guid>(id)
{
    
}