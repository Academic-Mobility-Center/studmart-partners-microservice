using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;

public class EfRepositoryBase<TEntity, TId>(DataContext context)
    : IRepository<TEntity, TId>, IDisposable, IAsyncDisposable where TEntity : class, IEntity<TId> where TId : struct
{
    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        await context.AddAsync(entity);
        var count = await context.SaveChangesAsync();
        return count > 0 ? entity : null;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
        (await context.Set<TEntity>().ToListAsync()).AsEnumerable();


    public virtual async Task<TEntity?> GetByIdAsync(TId id) => await context.Set<TEntity>().FindAsync(id);

    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {        await context.DisposeAsync();
    }
}