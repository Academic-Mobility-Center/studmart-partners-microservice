using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class PartnerRegionsNotFoundResult(Guid notFoundId) : NotFoundResultBase<Guid>(notFoundId)
{
    
}