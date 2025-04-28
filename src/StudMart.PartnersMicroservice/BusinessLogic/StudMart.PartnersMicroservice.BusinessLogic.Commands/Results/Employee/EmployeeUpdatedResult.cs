using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;

public class EmployeeUpdatedResult(EmployeeModel model) : UpdatedResultBase<EmployeeModel>(model)
{
    
}