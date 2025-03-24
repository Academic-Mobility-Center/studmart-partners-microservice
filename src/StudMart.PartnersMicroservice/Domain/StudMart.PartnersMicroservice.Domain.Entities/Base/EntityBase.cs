using System.Numerics;

namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

public abstract class EntityBase<TId>(TId id) : IEntity<TId>, IEquatable<EntityBase<TId>>,
    IEqualityOperators<EntityBase<TId>, EntityBase<TId>, bool>, IEqualityComparer<EntityBase<Guid>>
{
    public TId Id { get; } = id;

    public bool Equals(EntityBase<TId>? other)
    {
        if (other is null) return false;
        return ReferenceEquals(this, other) || EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((EntityBase<TId>)obj);
    }

    public override int GetHashCode()
    {
        if (Id is null)
            throw new NullReferenceException();
        return EqualityComparer<TId>.Default.GetHashCode(Id);
    }

    public static bool operator ==(EntityBase<TId>? left, EntityBase<TId>? right)
    {

        if (left is null && right is null)
            return true;
        if (left is null && right is not null)
            return false;
        if (right is null && left is not null)
            return false;
        return left!.GetType().FullName == right!.GetType().FullName && left!.Equals(right);
    }

    public static bool operator !=(EntityBase<TId>? left, EntityBase<TId>? right) => !(left == right);

    public bool Equals(EntityBase<Guid>? x, EntityBase<Guid>? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        return x.GetType() == y.GetType() && ((object)x.Id).Equals(y.Id);
    }

    public int GetHashCode(EntityBase<Guid> obj)
    {
        return obj.Id.GetHashCode();
    }
}