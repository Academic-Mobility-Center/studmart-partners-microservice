using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class CreatePartnerCommand(PartnerAddModel model) : CreateCommandBase<PartnerModel, PartnerAddModel>(model)
{
    
}