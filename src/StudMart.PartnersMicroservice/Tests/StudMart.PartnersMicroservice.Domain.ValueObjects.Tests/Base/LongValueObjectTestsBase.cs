using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Base;

public class LongValueObjectTestsBase<TValueObject, TException> : ValueObjectTestsBase<TValueObject, TException, long>
where TValueObject : SingleParameterValueObjectBase<long>
where TException : InvalidValueObjectValueFormatExceptionBase;