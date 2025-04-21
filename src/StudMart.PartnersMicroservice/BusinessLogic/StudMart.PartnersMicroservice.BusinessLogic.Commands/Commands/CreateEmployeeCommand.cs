using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class CreateEmployeeCommand(EmployeeAddModel model) : CreateCommandBase<EmployeeAddModel>(model)
{
    
}