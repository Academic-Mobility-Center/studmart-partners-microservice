using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;

public record EmployeeShortResponse(Guid id, string FirstName, string LastName, string Email) : IResponse;
