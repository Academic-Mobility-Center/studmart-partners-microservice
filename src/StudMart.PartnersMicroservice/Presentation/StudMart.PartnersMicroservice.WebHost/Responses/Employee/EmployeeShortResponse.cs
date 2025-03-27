using StudMart.PartnersMicroservice.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Employee;

public record EmployeeShortResponse(Guid id, string FirstName, string LastName, string Email) : IResponse;
