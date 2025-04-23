using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class PartnerAlreadyRegisteredResult(long inn) : IBadRequestResult
{
    public long Inn => inn;
}