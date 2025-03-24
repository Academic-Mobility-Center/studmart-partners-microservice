using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CompanyName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class CompanyNameValidatorTests() : NameValidatorTestsBase<CompanyNameValidator, InvalidCompanyNameException>(new CompanyNameValidator(),"Company name '{0}' is incorrect")
{
    /// <summary>
    /// Method that verifies exception if incorrect company name given
    /// </summary>
    /// <param name="name">incorrect company name address</param>
    [Theory]
    [GenericClassData<IncorrectCompanyNameTestsData>]
    public override void ValidationShouldNotBeCorrect(string name) => base.ValidationShouldNotBeCorrect(name);

    /// <summary>
    /// Method that verifies logic of correct company name 
    /// </summary>
    /// <param name="name">Correct company name</param>
    [Theory]
    [GenericClassData<CorrectCompanyNameTestsData>]
    public override void ValidationShouldBeCorrect(string name) => base.ValidationShouldBeCorrect(name);
}