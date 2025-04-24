using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class PartnerNameAlreadyRegisteredResult(string name) : IBadRequestResult
{
    public string Name => name;
}