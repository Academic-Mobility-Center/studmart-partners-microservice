using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.DescriptionRequest;

public class DescriptionRequestCreatedResult(Entities.DescriptionRequest createdEntity) : CreatedResultBase<Entities.DescriptionRequest, Guid>(createdEntity)
{
    
}