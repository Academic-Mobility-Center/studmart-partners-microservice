using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Email;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

/// <summary>
/// Class that verifies logic of email validator
/// </summary>
public class EmailValidatorTests
{
    /// <summary>
    /// Email validator object to test logic of email validation
    /// </summary>
    private readonly EmailValidator _validator = new();
    /// <summary>
    /// Method thar verifies exception if incorrect email given
    /// </summary>
    /// <param name="email">incorrect email address</param>
    [Theory]
    [ClassData(typeof(IncorrectEmailTestData))]
    public void EmailShouldBeIncorrect(string email)
    {
        var exception = FluentActions.Invoking(() => _validator.Validate(email)).Should().Throw<InvalidEmailException>().WithMessage($"Email {email} is incorrect").Which;
        exception.Email.Should().Be(email);
    }
    /// <summary>
    /// Method that verifies logic of correct email addresses of employees
    /// </summary>
    /// <param name="email">Correct email address of employee</param>
    [Theory]
    [ClassData(typeof(CorrectEmailTestsData))]
    public void EmailsShouldBeCorrect(string email) =>
        FluentActions.Invoking(() => _validator.Validate(email)).Should().NotThrow();
}