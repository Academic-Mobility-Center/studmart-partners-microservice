using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts;

public record RegionContract(string Name, int CountryId) : AbstractNamedContract(Name);
