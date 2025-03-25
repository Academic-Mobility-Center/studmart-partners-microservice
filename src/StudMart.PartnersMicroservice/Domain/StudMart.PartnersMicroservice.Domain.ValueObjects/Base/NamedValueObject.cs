using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

public abstract class NamedValueObject<TValue>(TValue value, IValidator<TValue> validator)
    : SingleParameterValueObjectBase<TValue>(value, validator), INamedValueObject<TValue>
{
    public TValue Name { get; } = value;

    public bool Equals(NamedValueObject<TValue> other)
    {
        return base.Equals(other) && EqualityComparer<TValue>.Default.Equals(Name, other.Name);
    }

    public bool Equals(IEquatableValueObject? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((NamedValueObject<TValue>)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Name);
    }
}