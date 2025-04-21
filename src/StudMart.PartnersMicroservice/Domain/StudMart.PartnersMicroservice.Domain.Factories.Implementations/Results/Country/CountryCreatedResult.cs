using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Country;

public class CountryCreatedResult(Entities.Country createdEntity) : CreatedResultBase<Entities.Country, int>(createdEntity)
{
    
}