using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class CreateDescriptionRequestCommand(DescriptionRequestAddModel model) : CreateCommandBase<DescriptionRequestAddModel>(model)
{
    
}