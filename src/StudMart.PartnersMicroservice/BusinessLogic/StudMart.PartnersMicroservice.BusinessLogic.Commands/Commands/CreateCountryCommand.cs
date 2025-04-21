using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class CreateCountryCommand(CountryAddModel model) : CreateCommandBase<CountryAddModel>(model)
{
    
}