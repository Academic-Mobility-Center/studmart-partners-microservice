using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Region;

public record RegionAddModel(string Name, int CountryId) : IAddModel
{
    
}