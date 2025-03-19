using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Phone;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

/// <summary>
/// Class that tests logic of phone validation
/// </summary>
public class PhoneValidatorTests
{
    /// <summary>
    /// Phone validator object to test logic
    /// </summary>
    private readonly PhoneValidator _validator = new();
    /// <summary>
    /// Valid mobile phones tests
    /// </summary>
    /// <param name="phone">Correct mobile phone of employee</param>
    [Theory]
    [ClassData(typeof(CorrectPhoneTestsData))]
    public void PhoneShouldBeValid(string phone) =>
        FluentActions.Invoking(() => _validator.Validate(phone)).Should().NotThrow();
    /// <summary>
    /// Method that validates incorrect mobile phones logic
    /// </summary>
    /// <param name="phone">Incorrect mobile phone</param>
    [Theory]
    [ClassData(typeof(IncorrectPhoneTestsData))]
    public void PhoneShouldBeInvalid(string phone)
    {
        var exception = FluentActions.Invoking(() => _validator.Validate(phone)).Should()
            .Throw<InvalidPhoneNumberException>().WithMessage($"Phone {phone} is incorrect").Which;
        exception.Phone.Should().Be(phone);
    }
}