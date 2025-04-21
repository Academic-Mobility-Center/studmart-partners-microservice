using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Category;

public class GetCategoryByNameRequest(string name) : GetByNameRequestBase<CategoryModel>(name)
{
    
}