using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests;

public class InnTests : LongValueObjectTestsBase<Inn, InvalidInnException>
{
    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueObjectShouldBeCreated(long value) => base.ValueObjectShouldBeCreated(value);

    [Theory]
    [GenericClassData<IncorrectInnTestData>]
    public override void ValueObjectShouldNotBeCreated(long value) => base.ValueObjectShouldNotBeCreated(value);


    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(long value) =>
        base.HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(value);


    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void StringValueOfObjectShouldEqualsSimpleTypeValue(long value) =>
        base.StringValueOfObjectShouldEqualsSimpleTypeValue(value);

    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueOfObjectShouldEqualsSimpleTypeStringValue(long value) =>
        base.ValueOfObjectShouldEqualsSimpleTypeStringValue(value);

    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByOperator(long value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByOperator(long value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(long value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(long value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(long value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(value);

    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValueObjectsShouldNotBeEqualsByOperator(long value) =>
        base.ValueObjectsShouldNotBeEqualsByOperator(value);
}