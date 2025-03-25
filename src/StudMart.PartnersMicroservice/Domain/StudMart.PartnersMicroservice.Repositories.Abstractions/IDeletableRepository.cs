using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IDeletableRepository<TEntity, in TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId> where TId : struct

{
    Task<bool> DeleteAsync(TEntity entity);
}