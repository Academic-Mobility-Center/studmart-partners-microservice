using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.DescriptionRequest;

public class DescriptionRequestRejectedResult(EmployeeModel employeeModel) : ISuccessResult
{
    public EmployeeModel Employee => employeeModel;
}