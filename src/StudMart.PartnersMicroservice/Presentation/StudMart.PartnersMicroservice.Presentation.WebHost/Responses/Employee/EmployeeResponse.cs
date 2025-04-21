using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Partner;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;

public record EmployeeResponse(Guid Id, string FirstName, string LastName, string Email, PartnerShortResponse Partner) : IResponse;