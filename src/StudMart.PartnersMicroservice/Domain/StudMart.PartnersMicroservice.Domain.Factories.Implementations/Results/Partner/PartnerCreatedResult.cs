using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;

public class PartnerCreatedResult(Entities.Aggregates.Partner createdEntity) : CreatedResultBase<Entities.Aggregates.Partner, Guid>(createdEntity)
{
    
}