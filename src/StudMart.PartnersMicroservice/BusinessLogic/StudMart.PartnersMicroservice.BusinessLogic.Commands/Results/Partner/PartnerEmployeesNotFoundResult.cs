using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class PartnerEmployeesNotFoundResult(Guid notFoundId) : NotFoundResultBase<Guid>(notFoundId)
{
    
}