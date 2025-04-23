using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IEmailEntityRepository<TEntity,  in TId> : IRepository<TEntity, TId>
where TEntity : class, IEntity<TId>
where TId : struct,IEquatable<TId>
{
    Task<TEntity?> GetByEmailAsync(Email email, CancellationToken cancellationToken);
}