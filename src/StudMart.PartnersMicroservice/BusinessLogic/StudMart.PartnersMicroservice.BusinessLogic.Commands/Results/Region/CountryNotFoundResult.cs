using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;

public class CountryNotFoundResult(int notFoundId) : NotFoundResultBase<int>(notFoundId)
{
    
}