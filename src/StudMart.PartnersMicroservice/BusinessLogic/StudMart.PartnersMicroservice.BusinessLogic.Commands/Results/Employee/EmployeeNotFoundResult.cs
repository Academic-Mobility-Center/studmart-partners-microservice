using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;

public class EmployeeNotFoundResult(Guid notFoundId) : NotFoundResultBase<Guid>(notFoundId)
{
    
}