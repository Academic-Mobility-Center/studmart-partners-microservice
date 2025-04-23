using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class PartnerEmailAlreadyRegisteredResult(string email) : IBadRequestResult
{
    public string Email => email;
}