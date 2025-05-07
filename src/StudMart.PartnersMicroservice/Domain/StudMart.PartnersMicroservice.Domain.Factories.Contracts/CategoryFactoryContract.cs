using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts;

public record CategoryFactoryContract(string Name, int Priority) : IFactoryContract;