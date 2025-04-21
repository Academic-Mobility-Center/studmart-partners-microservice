using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Category;

public class CategoryAlreadyExistsResult(Entities.Category entity) : EntityAlreadyExistsResultBase<Entities.Category, int>(entity)
{
    
}