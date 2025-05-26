using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.DescriptionRequest;

public class DescriptionRequestNotFoundResult(Guid notFoundId) : NotFoundResultBase<Guid>(notFoundId)
{
    
}