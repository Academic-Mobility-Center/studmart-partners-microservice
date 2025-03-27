using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

public abstract class GetByIdRequestBase<TModel, TId>(TId id) : IGetByIdRequest<TModel, TId> where TId: struct where TModel : class, IModel
{
    public TId Id { get; } = id;
}