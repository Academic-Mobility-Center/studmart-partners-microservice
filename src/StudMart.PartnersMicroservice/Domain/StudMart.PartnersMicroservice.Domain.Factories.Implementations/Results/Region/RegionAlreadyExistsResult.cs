using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Region;

public class RegionAlreadyExistsResult(Entities.Region entity) : EntityAlreadyExistsResultBase<Entities.Region, int>(entity)
{
    
}