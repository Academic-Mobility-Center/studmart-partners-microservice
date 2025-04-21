using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IRepository<TEntity, in TId> : IDisposable, IAsyncDisposable where TEntity : class, IEntity<TId> where TId : struct
{
    Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
}