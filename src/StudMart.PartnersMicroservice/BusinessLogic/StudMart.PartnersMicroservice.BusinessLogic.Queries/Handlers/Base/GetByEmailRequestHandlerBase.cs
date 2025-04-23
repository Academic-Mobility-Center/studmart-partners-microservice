using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;

public class GetByEmailRequestHandlerBase<TRequest, TModel, TEntity, TId>(
    IEmailEntityRepository<TEntity, TId> repository,
    IMapper mapper) : IRequestHandler<TRequest, TModel?>, IDisposable, IAsyncDisposable
    where TRequest : IGetByEmailRequest<TModel?>
    where TModel : class?, IModel?
    where TEntity : class, IEntity<TId>
    where TId : struct, IEquatable<TId>
{
    public async Task<TModel?> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByEmailAsync(new Email(request.Email), cancellationToken);
        return entity is null ? null : mapper.Map<TModel?>(entity);
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