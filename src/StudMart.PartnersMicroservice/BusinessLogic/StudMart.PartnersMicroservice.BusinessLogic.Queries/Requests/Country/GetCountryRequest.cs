using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Country;

public class GetCountryRequest(int id) : GetByIdRequestBase<CountryModel, int>(id)
{
    
}