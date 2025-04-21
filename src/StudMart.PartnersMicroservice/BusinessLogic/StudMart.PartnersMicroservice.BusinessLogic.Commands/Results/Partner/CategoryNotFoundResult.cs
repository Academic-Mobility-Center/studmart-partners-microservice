using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class CategoryNotFoundResult(int notFoundId) : NotFoundResultBase<int>(notFoundId)
{
    
}