using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Region;

public class CountryNotFoundResult(int id) : NotFoundResultBase<int>(id)
{
    
}