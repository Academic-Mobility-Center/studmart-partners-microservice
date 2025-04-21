using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;

public class GetRegionByNameRequest(string name) : GetByNameRequestBase<RegionModel>(name)
{
    
}