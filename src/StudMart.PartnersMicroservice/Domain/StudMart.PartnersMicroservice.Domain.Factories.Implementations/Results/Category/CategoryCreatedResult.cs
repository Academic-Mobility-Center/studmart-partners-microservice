using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Category;

public class CategoryCreatedResult(Entities.Category createdEntity) : CreatedResultBase<Entities.Category, int>(createdEntity)
{
    
}