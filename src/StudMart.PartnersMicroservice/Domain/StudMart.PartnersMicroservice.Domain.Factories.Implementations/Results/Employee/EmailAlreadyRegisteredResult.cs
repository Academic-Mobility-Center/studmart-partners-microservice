using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;

public class EmailAlreadyRegisteredResult(string email) : IBadRequestResult
{
    public string Email => email;
}