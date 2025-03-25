using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions;

public interface IEntityFactory<out TEntity, TId, in TContract>
    where TEntity : class, IEntity<TId> where TContract : IFactoryContract
{
    TEntity Create(TContract contract);
}