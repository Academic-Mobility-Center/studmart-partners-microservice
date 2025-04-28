using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

public record UpdateEmployeeModel(Guid Id, string FirstName, string LastName, string Email, Guid PartnerId) : UpdateModelBase(Id);