using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.DescriptionRequest;

public class DescriptionRequestAcceptedResult(EmployeeModel employee, PartnerModel partner) : ISuccessResult
{
    public EmployeeModel Employee => employee;
    public PartnerModel Partner => partner;
}