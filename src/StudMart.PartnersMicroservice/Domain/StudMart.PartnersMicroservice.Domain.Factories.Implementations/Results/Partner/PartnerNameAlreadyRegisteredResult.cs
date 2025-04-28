using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;

public class PartnerNameAlreadyRegisteredResult(string name) : IBadRequestResult
{
    public string Name => name;
}