namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

/// <summary>
/// Base class for entities that have Guid Id property
/// </summary>
public abstract class GuidIdentifierEntity : IEntity<Guid>
{
    /// <summary>
    /// Identifier of entity
    /// </summary>
    public Guid Id { get; init; }
    /// <summary>
    /// Constructor that creates entity with integer identifier 
    /// </summary>
    /// <param name="id">Identifier of entity</param>
    protected GuidIdentifierEntity(Guid id)
    {
        Id = id;
    }
}