using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.FirstName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.FirstName;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests;

public class FirstNameTests : StringValueObjectTestsBase<FirstName, InvalidFirstNameException>
{
    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueObjectShouldBeCreated(string value) => base.ValueObjectShouldBeCreated(value);

    [Theory]
    [GenericClassData<IncorrectFirstNameTestsData>]
    public override void ValueObjectShouldNotBeCreated(string value) => base.ValueObjectShouldNotBeCreated(value);


    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(string value) =>
        base.HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(value);


    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void StringValueOfObjectShouldEqualsSimpleTypeValue(string value) =>
        base.StringValueOfObjectShouldEqualsSimpleTypeValue(value);

    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueOfObjectShouldEqualsSimpleTypeStringValue(string value) =>
        base.ValueOfObjectShouldEqualsSimpleTypeStringValue(value);

    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByOperator(string value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByOperator(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(string value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(value);

    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValueObjectsShouldNotBeEqualsByOperator(string value) =>
        base.ValueObjectsShouldNotBeEqualsByOperator(value);
}