using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts;

public record CountryContract(string Name) : AbstractNamedContract(Name);