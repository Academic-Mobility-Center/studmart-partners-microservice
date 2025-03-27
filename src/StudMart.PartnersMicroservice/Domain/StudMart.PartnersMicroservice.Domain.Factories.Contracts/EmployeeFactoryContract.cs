using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Contracts;

public record EmployeeFactoryContract(string FirstName, string LastName, string Email, Guid PartnerId) : IFactoryContract;
