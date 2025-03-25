using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions;

public interface IEntityFactory<TEntity, TId, in TContract>
    where TEntity : class, IEntity<TId> where TContract : IFactoryContract
{
    Task<TEntity> Create(TContract contract);
}