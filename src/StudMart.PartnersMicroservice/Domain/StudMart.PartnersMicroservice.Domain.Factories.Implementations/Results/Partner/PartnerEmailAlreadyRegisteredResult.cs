using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;

public class PartnerEmailAlreadyRegisteredResult(string email) : IBadRequestResult
{
    public string Email  =>  email;
    
}