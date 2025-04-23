using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;

public class PartnerAlreadyRegisteredResult(long inn) : IBadRequestResult
{
    public long Inn => inn;
}