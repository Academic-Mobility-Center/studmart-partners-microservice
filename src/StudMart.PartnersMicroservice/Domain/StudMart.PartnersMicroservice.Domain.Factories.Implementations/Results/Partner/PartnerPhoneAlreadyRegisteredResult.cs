using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;

public class PartnerPhoneAlreadyRegisteredResult(string phone) : IBadRequestResult
{
    public string Phone => phone;
}