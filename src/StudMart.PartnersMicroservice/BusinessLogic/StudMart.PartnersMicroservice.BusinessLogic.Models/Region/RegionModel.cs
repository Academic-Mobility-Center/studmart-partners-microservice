using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Region;

public record RegionModel(int Id, string Name, CountryModel Country) : IModel
{
    
}