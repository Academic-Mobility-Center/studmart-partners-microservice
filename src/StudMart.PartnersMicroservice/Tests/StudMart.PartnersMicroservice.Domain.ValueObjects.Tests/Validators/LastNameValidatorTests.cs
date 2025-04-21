using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.LastName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.LastName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class LastNameValidatorTests() : NameValidatorTestsBase<LastNameValidator,InvalidLastNameException>(new LastNameValidator(), "Last name '{0}' is incorrect")
{
    /// <summary>
    /// Method that verifies exception if incorrect last name of person given
    /// </summary>
    /// <param name="name">incorrect last name</param>
    [Theory]
    [GenericClassData<IncorrectLastNameTestsData>]
    public override void ValidationShouldNotBeCorrect(string name) => base.ValidationShouldNotBeCorrect(name);


    /// <summary>
    /// Method that verifies logic of correct last name of person
    /// </summary>
    /// <param name="name">Correct last name of person</param>
    [Theory]
    [GenericClassData<CorrectLastNameTestsData>]
    public override void ValidationShouldBeCorrect(string name) => base.ValidationShouldBeCorrect(name);
}