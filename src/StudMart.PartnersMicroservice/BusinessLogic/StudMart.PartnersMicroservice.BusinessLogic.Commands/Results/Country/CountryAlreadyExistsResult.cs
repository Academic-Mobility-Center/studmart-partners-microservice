using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Country;

public class CountryAlreadyExistsResult(string name) : AlreadyExistsResultBase
{
    public string Name => name;
}