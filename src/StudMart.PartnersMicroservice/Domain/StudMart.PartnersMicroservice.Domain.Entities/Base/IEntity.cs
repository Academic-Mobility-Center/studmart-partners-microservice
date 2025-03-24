namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

/// <summary>
/// Interface thar represents entity value
/// </summary>
/// <typeparam name="TId">Type of Id field</typeparam>
public interface IEntity<out TId>
{
    /// <summary>
    /// Field that represents Id into repository
    /// </summary>
    public TId Id { get;  }
}