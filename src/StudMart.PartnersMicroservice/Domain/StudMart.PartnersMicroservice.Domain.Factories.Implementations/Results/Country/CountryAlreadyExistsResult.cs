using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Country;

public class CountryAlreadyExistsResult(Entities.Country entity) : EntityAlreadyExistsResultBase<Entities.Country, int>(entity)
{
    
}