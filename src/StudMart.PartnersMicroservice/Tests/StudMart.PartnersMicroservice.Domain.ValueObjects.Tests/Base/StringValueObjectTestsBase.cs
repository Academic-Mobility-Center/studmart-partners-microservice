using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Base;

public abstract class
    StringValueObjectTestsBase<TValueObject, TException> : ValueObjectTestsBase<TValueObject, TException, string>
    where TValueObject : SingleParameterValueObjectBase<string>
    where TException : InvalidValueObjectValueFormatException;

