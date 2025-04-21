using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IEmailEntityRepository<TEntity,  in TId> : IRepository<TEntity, TId>
where TEntity : class, IEntity<TId>
where TId : struct,IEquatable<TId>
{
    Task<TEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}