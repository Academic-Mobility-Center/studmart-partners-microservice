namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

public interface INamedValueObject<out TName> : IEquatableValueObject
{
    public TName Name { get;  }
    
}