using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Phone;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests;

/// <summary>
/// Class that contains unit tests to validate mobile phone numbers
/// </summary>
public class PhoneTests
{
    /// <summary>
    /// Correct phone number validation test
    /// </summary>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhoneShouldBeCreated(string phone) => FluentActions.Invoking(() => new Phone(phone)).Should().NotThrow();
    /// <summary>
    /// Incorrect phone numbers tests
    /// </summary>
    /// <param name="number">PMobile phone number that is incorrect</param>
    [Theory]
    [ClassData(typeof(IncorrectPhoneTestsData))]
    public void PhoneShouldNotBeCreated(string number)
    {
        var exception = FluentActions.Invoking(() => new Phone(number)).Should()
            .Throw<InvalidPhoneNumberException>().WithMessage($"Phone {number} is incorrect").Which;
        exception.Phone.Should().Be(number);

    }
        /// <summary>
    /// Method verifies that hash code of object equals hash code of value
    /// </summary>
    /// <param name="phone">Phone to verify hash codes</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void HashCodeOfPhoneShouldEqualsHashCodeOfPhoneObject(string phone)
    {
        var mail = new Phone(phone);
        phone.GetHashCode().Should().Be(mail.GetHashCode());
    }
    /// <summary>
    /// Method verifies that string value of object equals simple type string value
    /// </summary>
    /// <param name="number">Phone to verify string equity</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void StringValueOfObjectShouldEqualsSimpleTypeValue(string number)
    {
        var telephone = new Phone(number);
        var phone = telephone.ToString();
        phone.Should().Be(number);
    }
    /// <summary>
    /// Verify that Value property of object equals simple type value
    /// </summary>
    /// <param name="phone">Phone to verify Value property equity</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void ValueOfObjectShouldEqualsSimpleTypeStringValue(string phone)
    {
        var mail = new Phone(phone);
        mail.Value.Should().Be(phone);
    }
    /// <summary>
    /// Validates that Phones with same reference are equals
    /// </summary>
    /// <param name="phone">Phone to validate</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhonesWithSameReferencesShouldEqualsByOperator(string phone)
    {
        var first = new Phone(phone);
        var second = first;
        Assert.True(first==second);
    }
    /// <summary>
    /// Phone objects with the same simple type value must be equals
    /// </summary>
    /// <param name="phone">Phone to validate</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhonesWithSameValuesShouldBeEqualsByOperator(string phone)
    {
        var first = new Phone(phone);
        var second = new Phone(phone);
        Assert.True(first==second);
    }
    /// <summary>
    /// Validates that Phones with same reference are equals
    /// </summary>
    /// <param name="phone">Phone to validate</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhonesWithSameReferencesShouldEqualsByEqualsMethod(string phone)
    {
        var first = new Phone(phone);
        var second = first;
        Assert.True(first.Equals(second));
    }
    /// <summary>
    /// Phone objects with the same simple type value must be equals
    /// </summary>
    /// <param name="phone">Phone to validate</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhonesWithSameValuesShouldBeEqualsByEqualsMethod(string phone)
    {
        var first = new Phone(phone);
        var second = new Phone(phone);
        Assert.True(first.Equals(second));
    }
    /// <summary>
    /// Phone objects with the same simple type value must be equals
    /// </summary>
    /// <param name="phone">Phone phone to validate</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhonesWithSameValuesShouldBeEqualsByEqualsMethodT(string phone)
    {
        var first = new Phone(phone);
        Assert.True(first.Equals(phone));
    }
    /// <summary>
    /// Validates that different Phones are not equal
    /// </summary>
    /// <param name="phone">Phone to validate</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhonesShouldNotBeEqualsByOperator(string phone)
    {
        var first = new Phone(phone);
        var second = new Phone("+79139617696");
        Assert.True(first!=second);
    }

}