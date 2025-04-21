using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.LastName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.LastName;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests;

public class LastNameTests : StringValueObjectTestsBase<LastName, InvalidLastNameException>
{
    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueObjectShouldBeCreated(string value) => base.ValueObjectShouldBeCreated(value);

    [Theory]
    [GenericClassData<IncorrectLastNameTestsData>]
    public override void ValueObjectShouldNotBeCreated(string value) => base.ValueObjectShouldNotBeCreated(value);


    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(string value) =>
        base.HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(value);


    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void StringValueOfObjectShouldEqualsSimpleTypeValue(string value) =>
        base.StringValueOfObjectShouldEqualsSimpleTypeValue(value);

    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueOfObjectShouldEqualsSimpleTypeStringValue(string value) =>
        base.ValueOfObjectShouldEqualsSimpleTypeStringValue(value);

    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByOperator(string value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByOperator(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(string value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(value);

    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValueObjectsShouldNotBeEqualsByOperator(string value) =>
        base.ValueObjectsShouldNotBeEqualsByOperator(value);
}