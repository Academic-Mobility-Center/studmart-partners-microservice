using StudMart.PartnersMicroservice.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.WebHost.Requests.Employee;

public record EmployeeAddRequest(string Email, string FirstName, string LastName, Guid PartnerId) : IRequest;