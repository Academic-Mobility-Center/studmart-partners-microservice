using StudMart.PartnersMicroservice.WebHost.Responses.Base;
using StudMart.PartnersMicroservice.WebHost.Responses.Partner;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Employee;

public record EmployeeResponse(Guid Id, string FirstName, string LastName, string Email, PartnerShortResponse Partner) : IResponse;