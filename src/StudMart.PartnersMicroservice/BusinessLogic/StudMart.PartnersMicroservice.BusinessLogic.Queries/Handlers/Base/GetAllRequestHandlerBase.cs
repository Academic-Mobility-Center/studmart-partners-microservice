using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;

public class GetAllRequestHandlerBase<TRequest, TId, TModel, TEntity>(IRepository<TEntity, TId> repository, IMapper mapper)
    : IRequestHandler<TRequest, IEnumerable<TModel>>
    where TRequest : IGetAllRequest<TModel>
    where TModel : class, IModel
    where TEntity : class, IEntity<TId>
    where TId : struct
{
    public async Task<IEnumerable<TModel>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync(cancellationToken);
        return entities.Select(mapper.Map<TEntity, TModel>);
    }
}