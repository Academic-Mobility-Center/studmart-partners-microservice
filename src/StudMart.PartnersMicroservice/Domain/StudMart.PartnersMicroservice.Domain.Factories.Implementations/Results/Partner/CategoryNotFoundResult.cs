using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;

public class CategoryNotFoundResult(int id) : NotFoundResultBase<int>(id)
{
    
}