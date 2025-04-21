using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

public class GetByNameRequestBase<TModel>(string name) : IGetByNameRequest<TModel> where TModel : class?, IModel?
{
    public string Name => name;
}