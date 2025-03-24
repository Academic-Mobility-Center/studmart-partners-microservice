using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Email;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

/// <summary>
/// Class that verifies logic of email validator
/// </summary>
public class EmailValidatorTests() : ValidatorTestsBase<EmailValidator, string, InvalidEmailException>(new EmailValidator(), "Email {0} is incorrect", exception => exception.Email)
{
    /// <summary>
    /// Method thar verifies exception if incorrect email given
    /// </summary>
    /// <param name="email">incorrect email address</param>
    [Theory]
    [GenericClassData<IncorrectEmailTestData>]
    public override void ValidationShouldNotBeCorrect(string email) => base.ValidationShouldNotBeCorrect(email);


    /// <summary>
    /// Method that verifies logic of correct email addresses of employees
    /// </summary>
    /// <param name="email">Correct email address of employee</param>
    [Theory]
    [ClassData(typeof(CorrectEmailTestsData))]
    public override void ValidationShouldBeCorrect(string email) => base.ValidationShouldBeCorrect(email);
    
}