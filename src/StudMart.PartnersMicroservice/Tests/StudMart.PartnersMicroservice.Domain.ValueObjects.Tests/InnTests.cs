using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests;

/// <summary>
/// Class that contains all unit tests to verify INN Correction
/// </summary>
public class InnTests
{

    /// <summary>
    /// Verify real INN correction
    /// </summary>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void InnShouldBeCreated(long inn) => FluentActions.Invoking(() => new Inn(inn)).Should().NotThrow();

    /// <summary>
    /// Test that verify multiple incorrect INNs
    /// </summary>
    /// <param name="inn">INN that is incorrect</param>
    [Theory]
    [ClassData(typeof(IncorrectInnTestData))]
    public void InnShouldNotBeCreated(long inn)
    {

        var exception = FluentActions.Invoking(() => new Inn(inn)).Should().Throw<InvalidInnException>()
            .WithMessage($"INN {inn} is incorrect").Which;
        exception.Inn.Should().Be(inn);
    }

    /// <summary>
    /// Method verifies that hash code of object equals hash code of value
    /// </summary>
    /// <param name="inn">Inn to verify hash codes</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void HashCodeOfInnShouldEqualsHashCodeOfInnObject(long inn)
    {
        var mail = new Inn(inn);
        inn.GetHashCode().Should().Be(mail.GetHashCode());
    }

    /// <summary>
    /// Method verifies that string value of object equals simple type string value
    /// </summary>
    /// <param name="inn">Inn to verify string equity</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void StringValueOfObjectShouldEqualsSimpleTypeValue(long inn)
    {
        var mail = new Inn(inn);
        var address = mail.ToString();
        address.Should().Be(inn.ToString());
    }

    /// <summary>
    /// Verify that Value property of object equals simple type value
    /// </summary>
    /// <param name="inn">Inn to verify Value property equity</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void ValueOfObjectShouldEqualsSimpleTypeStringValue(long inn)
    {
        var mail = new Inn(inn);
        mail.Value.Should().Be(inn);
    }

    /// <summary>
    /// Validates that Inns with same reference are equals
    /// </summary>
    /// <param name="inn">Inn inn to validate</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void InnsWithSameReferencesShouldEqualsByOperator(long inn)
    {
        var first = new Inn(inn);
        var second = first;
        Assert.True(first == second);
    }

    /// <summary>
    /// Inn objects with the same simple type value must be equals
    /// </summary>
    /// <param name="inn">Inn inn to validate</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void InnsWithSameValuesShouldBeEqualsByOperator(long inn)
    {
        var first = new Inn(inn);
        var second = new Inn(inn);
        Assert.True(first == second);
    }

    /// <summary>
    /// Validates that Inns with same reference are equals
    /// </summary>
    /// <param name="inn">Inn inn to validate</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void InnsWithSameReferencesShouldEqualsByEqualsMethod(long inn)
    {
        var first = new Inn(inn);
        var second = first;
        Assert.True(first.Equals(second));
    }

    /// <summary>
    /// Inn objects with the same simple type value must be equals
    /// </summary>
    /// <param name="inn">Inn to validate</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void InnsWithSameValuesShouldBeEqualsByEqualsMethod(long inn)
    {
        var first = new Inn(inn);
        var second = new Inn(inn);
        Assert.True(first.Equals(second));
    }

    /// <summary>
    /// Inn objects with the same simple type value must be equals
    /// </summary>
    /// <param name="inn">Inn inn to validate</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void InnsWithSameValuesShouldBeEqualsByEqualsMethodT(long inn)
    {
        var first = new Inn(inn);
        Assert.True(first.Equals(inn));
    }

    /// <summary>
    /// Validates that different Inns are not equal
    /// </summary>
    /// <param name="inn">Inn to validate</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void InnsShouldNotBeEqualsByOperator(long inn)
    {
        var first = new Inn(inn);
        var second = new Inn(5404227535);
        Assert.True(first != second);
    }
}