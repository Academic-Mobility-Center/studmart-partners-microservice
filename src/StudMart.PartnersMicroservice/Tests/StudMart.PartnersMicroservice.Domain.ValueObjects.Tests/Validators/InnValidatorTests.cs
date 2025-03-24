using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

/// <summary>
/// Class that verifies logic of email validator
/// </summary>
public class InnValidatorTests() : ValidatorTestsBase<InnValidator, long, InvalidInnException>(new InnValidator(), "Inn {0} is incorrect", exception => exception.Inn)
{
    /// <summary>
    /// Method that verifies exception if incorrect inn given
    /// </summary>
    /// <param name="inn">incorrect INN</param>
    [Theory]
    [GenericClassData<IncorrectInnTestData>]
    public override void ValidationShouldNotBeCorrect(long inn) => base.ValidationShouldNotBeCorrect(inn);


    /// <summary>
    /// Method that verifies logic of correct INN of organization
    /// </summary>
    /// <param name="inn">Correct real INN of organization</param>
    [Theory]
    [GenericClassData<CorrectInnTestsData>]
    public override void ValidationShouldBeCorrect(long inn) => base.ValidationShouldBeCorrect(inn);
    
}