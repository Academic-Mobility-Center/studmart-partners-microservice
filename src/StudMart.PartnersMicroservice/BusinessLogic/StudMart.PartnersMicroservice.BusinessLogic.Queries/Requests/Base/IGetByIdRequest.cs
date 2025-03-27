using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

public interface IGetByIdRequest<out TModel, out TId> : IRequest<TModel> where TId: struct where TModel : class, IModel
{
    TId Id { get; }
}