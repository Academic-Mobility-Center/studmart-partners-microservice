using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;

public class PartnerUpdatedResult(PartnerModel model) : UpdatedResultBase<PartnerModel>(model)
{
    
}