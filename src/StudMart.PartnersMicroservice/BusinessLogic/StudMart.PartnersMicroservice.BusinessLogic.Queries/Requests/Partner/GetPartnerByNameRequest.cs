using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;

public class GetPartnerByNameRequest(string name) : GetByNameRequestBase<PartnerModel>(name)
{
    
}