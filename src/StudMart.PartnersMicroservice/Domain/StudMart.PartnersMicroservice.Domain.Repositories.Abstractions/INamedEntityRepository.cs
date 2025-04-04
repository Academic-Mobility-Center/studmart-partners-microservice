using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface INamedEntityRepository<TEntity, in TId, in TName> : IRepository<TEntity, TId>
    where TEntity : class, INamedEntity<TId, TName> where TId : struct where TName : INamedValueObject<string>
{
    Task<TEntity?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}