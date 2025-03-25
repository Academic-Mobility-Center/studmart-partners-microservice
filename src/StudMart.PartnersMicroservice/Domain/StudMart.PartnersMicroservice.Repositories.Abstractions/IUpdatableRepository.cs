using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IUpdatableRepository<TEntity, in TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId> where TId : struct
{
    Task<bool> UpdateAsync(TEntity entity);
}