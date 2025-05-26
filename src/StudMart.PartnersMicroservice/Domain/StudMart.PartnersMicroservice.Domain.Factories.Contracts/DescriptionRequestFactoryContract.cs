using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts;

public record DescriptionRequestFactoryContract(string Description, Guid EmployeeId) : IFactoryContract;