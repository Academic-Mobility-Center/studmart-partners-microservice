using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Region;

public class RegionCreatedResult(Entities.Region createdEntity) : CreatedResultBase<Entities.Region, int>(createdEntity)
{
    
}