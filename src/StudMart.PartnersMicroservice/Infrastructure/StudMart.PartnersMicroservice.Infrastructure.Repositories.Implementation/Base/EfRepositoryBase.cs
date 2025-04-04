using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;

public class EfRepositoryBase<TEntity, TId>(DataContext context)
    : IRepository<TEntity, TId>, IDisposable, IAsyncDisposable where TEntity : class, IEntity<TId> where TId : struct
{
    public async Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        var count = await context.SaveChangesAsync(cancellationToken);
        return count > 0 ? entity : null;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        (await context.Set<TEntity>().ToListAsync(cancellationToken)).AsEnumerable();


    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default) =>
        await context.Set<TEntity>().FindAsync([id], cancellationToken: cancellationToken);

    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}