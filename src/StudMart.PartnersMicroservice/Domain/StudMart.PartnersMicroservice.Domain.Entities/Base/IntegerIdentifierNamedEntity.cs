using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

public abstract class IntegerIdentifierNamedEntity<TName>(int id, TName name)
    : IntegerIdentifierEntity(id), INamedEntity<int, TName>
    where TName : INamedValueObject<string>
{
    public TName Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
}