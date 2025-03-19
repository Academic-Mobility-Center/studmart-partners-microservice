using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

/// <summary>
/// Class that verifies logic of email validator
/// </summary>
public class InnValidatorTests
{
    /// <summary>
    /// Email validator object to test logic of email validation
    /// </summary>
    private readonly InnValidator _validator = new();
    /// <summary>
    /// Method that verifies exception if incorrect inn given
    /// </summary>
    /// <param name="inn">incorrect INN</param>
    [Theory]
    [ClassData(typeof(IncorrectInnTestData))]
    public void EmailShouldBeIncorrect(long inn)
    {
        var exception = FluentActions.Invoking(() => _validator.Validate(inn)).Should().Throw<InvalidInnException>().WithMessage($"Inn {inn} is incorrect").Which;
        exception.Inn.Should().Be(inn);
    }
    /// <summary>
    /// Method that verifies logic of correct INN of organization
    /// </summary>
    /// <param name="inn">Correct real INN of organization</param>
    [Theory]
    [ClassData(typeof(CorrectInnTestsData))]
    public void EmailsShouldBeCorrect(long inn) =>
        FluentActions.Invoking(() => _validator.Validate(inn)).Should().NotThrow();
}