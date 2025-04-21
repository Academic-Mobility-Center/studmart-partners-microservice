using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;

public class PartnerNotFoundResult(Guid id) : NotFoundResultBase<Guid>(id)
{
    
}