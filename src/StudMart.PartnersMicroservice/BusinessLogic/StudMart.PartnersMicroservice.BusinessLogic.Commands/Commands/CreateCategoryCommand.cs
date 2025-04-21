using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class CreateCategoryCommand(CategoryAddModel model) : CreateCommandBase<CategoryAddModel>(model)
{
    
}