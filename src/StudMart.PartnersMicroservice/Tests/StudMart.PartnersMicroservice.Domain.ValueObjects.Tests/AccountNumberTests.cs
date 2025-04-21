using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.AccountNumber;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.AccountNumber;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests;

public class AccountNumberTests : StringValueObjectTestsBase<AccountNumber, InvalidAccountNumberException>
{
    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueObjectShouldBeCreated(string value) => base.ValueObjectShouldBeCreated(value);

    [Theory]
    [GenericClassData<IncorrectAccountNumberTestsData>]
    public override void ValueObjectShouldNotBeCreated(string value) => base.ValueObjectShouldNotBeCreated(value);


    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(string value) =>
        base.HashCodeOfValueObjectShouldBeEqualToHashCodeOfValue(value);


    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void StringValueOfObjectShouldEqualsSimpleTypeValue(string value) =>
        base.StringValueOfObjectShouldEqualsSimpleTypeValue(value);

    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueOfObjectShouldEqualsSimpleTypeStringValue(string value) =>
        base.ValueOfObjectShouldEqualsSimpleTypeStringValue(value);

    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByOperator(string value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByOperator(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByOperator(value);


    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(string value) =>
        base.ValueObjectsWithSameReferencesShouldEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethod(value);


    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(string value) =>
        base.ValueObjectsWithSameValuesShouldBeEqualsByEqualsMethodWithValue(value);

    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValueObjectsShouldNotBeEqualsByOperator(string value) =>
        base.ValueObjectsShouldNotBeEqualsByOperator(value);
}