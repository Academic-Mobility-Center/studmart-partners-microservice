using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class PartnerPhoneAlreadyRegisteredResult(string phone) : IBadRequestResult
{
    public string Phone => phone;
}