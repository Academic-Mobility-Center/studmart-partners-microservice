using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;

public class GetByNameRequestHandlerBase<TRequest, TModel, TEntity, TId, TName>(
    INamedEntityRepository<TEntity, TId, TName> repository,
    IMapper mapper) : IRequestHandler<TRequest, TModel?>, IDisposable, IAsyncDisposable
    where TRequest : IGetByNameRequest<TModel>
    where TModel : class?, IModel?
    where TEntity : class, INamedEntity<TId, TName>
    where TId : struct
    where TName : INamedValueObject<string>
{
    public async Task<TModel?> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var constructor = typeof(TName).GetConstructor([typeof(string)]);
        if (constructor is null)
            throw new InvalidOperationException("Can not create value object to find");
        var name = (TName)constructor.Invoke([request.Name]);
        var entity = await repository.GetByNameAsync(name, cancellationToken);
        return entity is null ? null : mapper.Map<TModel>(entity);
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