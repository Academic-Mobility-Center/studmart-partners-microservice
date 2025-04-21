using System.Reflection;
using FakeItEasy;
using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;
using StudMart.PartnersMicroservice.Tests.Common.Helpers;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Base;

public abstract class ValueObjectTestsBase<TValueObject, TException, TValue>
    where TValueObject : SingleParameterValueObjectBase<TValue>
    where TException: InvalidValueObjectValueFormatExceptionBase
{
    private readonly IValidator<TValue> _validator = A.Fake<IValidator<TValue>>();

    private TValueObject? CreateValueObject(TValue value, IValidator<TValue> validator)
    {
        var constructor = GetConstructor();
        var result = constructor?.Invoke([value, _validator]) as TValueObject;
        return result;
    }
    private ConstructorInfo? GetConstructor() => typeof(TValueObject).GetConstructor(typeof(TValue), typeof(IValidator<TValue>));
        

    public virtual void ValueObjectShouldBeCreated(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var constructor = GetConstructor();
        var result = FluentActions.Invoking(() => constructor?.Invoke([value, _validator]) as TValueObject).Should().NotThrow().Which;
        result.Should().BeOfType<TValueObject>();
        result.Value.Should().Be(value);
    }

    public virtual void ValueObjectShouldNotBeCreated(TValue value)
    {
        var validator = A.Fake<IValidator<TValue>>();
        var exception = typeof(TException).GetInstance<TException>(value!);
        A.CallTo(() => validator.Validate(value)).Throws(exception ?? throw new NullReferenceException());
        var constructor = GetConstructor();
        var resultException = FluentActions.Invoking(() => constructor?.Invoke([value, validator]) as TValueObject).Should().Throw<Exception>().Which;
        resultException.InnerException.Should().Be(exception);
    }

    public virtual void HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var valueObject = CreateValueObject(value, _validator);
        valueObject?.GetHashCode().Should().Be(value?.GetHashCode());
    }
    
    
    public virtual void StringValueOfObjectShouldEqualsSimpleTypeValue(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var valueObject = CreateValueObject(value, _validator);
        valueObject?.ToString().Should().Be(value?.ToString());
    }

    public virtual void ValueOfObjectShouldEqualsSimpleTypeStringValue(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var valueObject = CreateValueObject(value, _validator);
        if (valueObject is null)
            throw new NullReferenceException();
        valueObject.ToString().Should().Be(value!.ToString());
    }

    public virtual void ValueObjectsWithSameReferencesShouldEqualsByOperator(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var first = CreateValueObject(value, _validator);
        var second = first;
        if(first is null || second is null)
            throw new NullReferenceException();
        Assert.True(first == second);
    }
    
    public virtual void ValueObjectsWithSameValuesShouldBeEqualsByOperator(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var first = CreateValueObject(value, _validator);
        var second = CreateValueObject(value,_validator);
        if(first is null || second is null)
            throw new NullReferenceException();
        Assert.True(first == second);
    }

    public virtual void ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var first = CreateValueObject(value, _validator);
        var second = first;
        if(first is null || second is null)
            throw new NullReferenceException();
        second.Equals(first).Should().BeTrue();
    }

    public virtual void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var first = CreateValueObject(value, _validator);
        var second = CreateValueObject(value, _validator);
        if(first is null || second is null)
            throw new NullReferenceException();

        first.Equals(second).Should().BeTrue();
    }

    public virtual void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(TValue value)
    {
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        var first = CreateValueObject(value, _validator);
        if(first is null)
            throw new NullReferenceException();
        first.Equals(value).Should().BeTrue();
    }

    public virtual void ValueObjectsShouldNotBeEqualsByOperator(TValue value)
    {
        var value2 = A.Dummy<TValue>(); 
        A.CallTo(() => _validator.Validate(value)).DoesNothing();
        A.CallTo(() => _validator.Validate(value2)).DoesNothing();
        var first = CreateValueObject(value, _validator);
        var second = CreateValueObject(value2, _validator);
        if(first is null || second is null)
            throw new NullReferenceException();
        Assert.True(first!=second);
    }
}