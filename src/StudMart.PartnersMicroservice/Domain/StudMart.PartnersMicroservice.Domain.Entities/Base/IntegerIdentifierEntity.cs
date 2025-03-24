using StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

/// <summary>
/// Base class for entities that have int Id property
/// </summary>
public abstract class IntegerIdentifierEntity : IEntity<int>
{
    /// <summary>
    /// Id value
    /// </summary>
    private readonly int _id;
    /// <summary>
    /// Method that validates integer Id for correction 
    /// </summary>
    /// <param name="id">Id that need to be validated</param>
    /// <exception cref="InvalidEntityIdentifierException"></exception>
    private static void ValidateId(int id)
    {
        if (id <= 0)
            throw new InvalidEntityIdentifierException(id);
    }
    /// <summary>
    /// Identifier of entity
    /// </summary>
    public required int Id
    {
        get => _id;
        init
        {
            ValidateId(value);
            _id = value;
        }
    }
    /// <summary>
    /// Constructor that creates entity with integer identifier 
    /// </summary>
    /// <param name="id">Identifier of entity</param>
    protected IntegerIdentifierEntity(int id)
    {
        Id = id;
    }
}