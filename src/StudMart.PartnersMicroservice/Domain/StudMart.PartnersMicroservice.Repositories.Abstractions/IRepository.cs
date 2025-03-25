using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IRepository<TEntity, in TId> where TEntity : class, IEntity<TId> where TId : struct
{
    Task<TEntity?> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TId id);
}