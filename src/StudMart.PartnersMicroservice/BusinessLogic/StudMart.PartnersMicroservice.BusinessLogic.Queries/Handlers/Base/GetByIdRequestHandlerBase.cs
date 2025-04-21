using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;

public abstract class GetByIdRequestHandlerBase<TRequest, TModel, TId, TEntity>(
    IRepository<TEntity, TId> repository,
    IMapper mapper) : IRequestHandler<TRequest, TModel?>, IDisposable, IAsyncDisposable where TRequest : IGetByIdRequest<TModel, TId>
    where TEntity : class, IEntity<TId>
    where TModel : class, IModel
    where TId : struct
{
    public async Task<TModel?> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return null;
        return mapper.Map<TEntity, TModel>(result);
    }

    public void Dispose()
    {
        repository.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await repository.DisposeAsync();
    }
}