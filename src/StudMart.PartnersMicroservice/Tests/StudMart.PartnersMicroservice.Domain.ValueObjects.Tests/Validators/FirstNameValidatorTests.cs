using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.FirstName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class FirstNameValidatorTests() : NameValidatorTestsBase<FirstNameValidator,InvalidFirstNameException>(new FirstNameValidator(), "First name '{0}' is incorrect")
{

    /// <summary>
    /// Method that verifies exception if incorrect last name of person given
    /// </summary>
    /// <param name="name">incorrect last name</param>
    [Theory]
    [GenericClassData<IncorrectFirstNameTestsData>]
    public override void ValidationShouldNotBeCorrect(string name) => base.ValidationShouldNotBeCorrect(name);
    

    /// <summary>
    /// Method that verifies logic of correct last name of person
    /// </summary>
    /// <param name="name">Correct last name of person</param>
    [Theory]
    [GenericClassData<CorrectFirstNameTestsData>]
    public override void ValidationShouldBeCorrect(string name) => base.ValidationShouldBeCorrect(name);
}