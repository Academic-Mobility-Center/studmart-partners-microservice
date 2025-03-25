using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

public interface INamedEntity<out TId, out TName>: IEntity<TId> where TName : INamedValueObject<string>
{
    public TName Name { get;  }
}