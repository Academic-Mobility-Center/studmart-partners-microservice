using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

public record EmployeeModel(Guid Id, string FirstName, string LastName, string Email, PartnerShortModel Partner)
    : IModel;
