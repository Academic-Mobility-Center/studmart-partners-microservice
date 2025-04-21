using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Category;

public class CategoryAlreadyExistsResult(string name) : AlreadyExistsResultBase
{
    public string Name { get; } = name;
}