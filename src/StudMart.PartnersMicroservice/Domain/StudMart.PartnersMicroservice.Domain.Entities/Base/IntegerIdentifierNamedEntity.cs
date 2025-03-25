using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

public class IntegerIdentifierNamedEntity<TName> : IntegerIdentifierEntity, INamedEntity<int, TName>
    where TName : INamedValueObject<string>
{
    public IntegerIdentifierNamedEntity(int id, TName name) : base(id)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public TName Name { get; }
}