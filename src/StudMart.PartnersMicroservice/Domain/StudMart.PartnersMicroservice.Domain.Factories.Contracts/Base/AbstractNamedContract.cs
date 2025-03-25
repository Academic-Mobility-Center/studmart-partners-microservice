namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

public abstract record AbstractNamedContract(string Name) : IFactoryContract;