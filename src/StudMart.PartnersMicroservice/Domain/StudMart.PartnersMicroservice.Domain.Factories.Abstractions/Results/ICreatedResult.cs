using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

public interface ICreatedResult<out TEntity, TId> : IResult where TEntity : class, IEntity<TId> where TId: struct
{
    TEntity CreatedEntity { get; }
}