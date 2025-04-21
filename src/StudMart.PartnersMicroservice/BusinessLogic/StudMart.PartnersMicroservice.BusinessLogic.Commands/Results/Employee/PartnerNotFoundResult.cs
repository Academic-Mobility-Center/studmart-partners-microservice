using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;

public class PartnerNotFoundResult(Guid notFoundId) : NotFoundResultBase<Guid>(notFoundId)
{
    
}