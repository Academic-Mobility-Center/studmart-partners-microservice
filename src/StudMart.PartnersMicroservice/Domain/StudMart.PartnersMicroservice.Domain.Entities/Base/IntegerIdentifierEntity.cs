using StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

/// <summary>
/// Base class for entities that have int Id property
/// </summary>
public abstract class IntegerIdentifierEntity : EntityBase<int>
{

    /// <summary>
    /// Constructor that creates entity with integer identifier 
    /// </summary>
    /// <param name="id">Identifier of entity</param>
    protected IntegerIdentifierEntity(int id) : base(id)
    {
        
    }

}