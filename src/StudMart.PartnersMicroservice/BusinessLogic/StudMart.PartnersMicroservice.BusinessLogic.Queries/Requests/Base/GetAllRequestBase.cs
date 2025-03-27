using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

public abstract class GetAllRequestBase<TModel> : IGetAllRequest<TModel> where TModel : class, IModel
{
    
}