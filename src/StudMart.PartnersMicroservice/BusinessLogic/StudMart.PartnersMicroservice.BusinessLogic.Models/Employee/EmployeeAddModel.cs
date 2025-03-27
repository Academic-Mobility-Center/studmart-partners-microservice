using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

public record EmployeeAddModel(string FirstName, string LastName, string Email, Guid PartnerId) : IAddModel;
