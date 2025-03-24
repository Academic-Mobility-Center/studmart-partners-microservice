using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CountryName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class CountryNameValidatorTests() : NameValidatorTestsBase<CountryNameValidator, InvalidCountryNameException>(new CountryNameValidator(), "Country name '{0}' is incorrect")
{
    /// <summary>
    /// Method that verifies logic of correct country name
    /// </summary>
    /// <param name="name">Correct country name</param>
    [Theory]
    [GenericClassData<CorrectCountryNameTestsData>]
    public override void ValidationShouldBeCorrect(string name) => base.ValidationShouldBeCorrect(name);
    
    /// <summary>
    /// Method that verifies exception if incorrect country name given
    /// </summary>
    /// <param name="name">incorrect country name address</param>
    [Theory]
    [GenericClassData<IncorrectCountryNameTestsData>]
    public override void ValidationShouldNotBeCorrect(string name) => base.ValidationShouldNotBeCorrect(name);

}