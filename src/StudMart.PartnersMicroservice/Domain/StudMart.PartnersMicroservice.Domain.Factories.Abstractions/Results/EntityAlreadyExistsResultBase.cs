using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

public abstract class EntityAlreadyExistsResultBase<TEntity, TId>(TEntity entity) : IBadRequestResult where TEntity: class, IEntity<TId> where TId : struct
{
    public TEntity Entity  => entity;
}