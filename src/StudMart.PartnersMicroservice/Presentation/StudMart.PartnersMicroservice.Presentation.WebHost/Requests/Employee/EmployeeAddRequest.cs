using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Employee;

public record EmployeeAddRequest(string Email, string FirstName, string LastName, Guid PartnerId) : IRequest;