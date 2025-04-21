using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;

public class RegionAlreadyExistsResult(string name) : AlreadyExistsResultBase
{
    public string Name => name;
}