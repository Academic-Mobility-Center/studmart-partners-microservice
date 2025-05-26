using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.DiscountDescription;

public record DescriptionRequestResponse(Guid Id, string Description, EmployeeResponse Employee);