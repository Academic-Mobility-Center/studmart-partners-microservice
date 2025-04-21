using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

public abstract class CreatedResultBase<TEntity, TId>(TEntity createdEntity) : ICreatedResult<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : struct
{
    public TEntity CreatedEntity { get; } = createdEntity;
}