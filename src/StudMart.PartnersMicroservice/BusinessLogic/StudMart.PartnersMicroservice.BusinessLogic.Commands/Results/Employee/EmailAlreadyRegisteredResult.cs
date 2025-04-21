using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;

public class EmailAlreadyRegisteredResult(string email) : AlreadyExistsResultBase
{
    public string Email => email;
}