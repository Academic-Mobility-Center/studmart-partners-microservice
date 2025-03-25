using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;

public class EfUpdatableRepositoryBase<TEntity, TId>(DataContext context) : EfRepositoryBase<TEntity, TId>(context),
    IUpdatableRepository<TEntity, TId> where TEntity : class, IEntity<TId> where TId : struct
{
    private readonly DataContext _context = context;

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var find = await GetByIdAsync(entity.Id, cancellationToken);
        if (find is null)
            return false;
        _context.Update(entity);
        var count = await _context.SaveChangesAsync(cancellationToken);
        return count > 0;
    }
}