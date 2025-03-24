namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

/// <summary>
/// Base class for entities that have Guid Id property
/// </summary>
public abstract class GuidIdentifierEntity(Guid id) : EntityBase<Guid>(id)
{

}