using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

public interface IGetAllRequest<out TModel> : IRequest<IEnumerable<TModel>> where TModel : class, IModel
{
    
}