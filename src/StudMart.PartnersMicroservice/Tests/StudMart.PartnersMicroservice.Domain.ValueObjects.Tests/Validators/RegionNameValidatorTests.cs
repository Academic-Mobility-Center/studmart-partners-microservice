using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.RegionName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class RegionNameValidatorTests() : NameValidatorTestsBase<RegionNameValidator,InvalidRegionNameException>(new RegionNameValidator(), "Region name '{0}' is incorrect")
{
    /// <summary>
    /// Method that verifies exception if incorrect region name of country given
    /// </summary>
    /// <param name="name">incorrect region name of country</param>
    [Theory]
    [GenericClassData<IncorrectRegionNameTestsData>]
    public override void ValidationShouldNotBeCorrect(string name) => base.ValidationShouldNotBeCorrect(name);

    /// <summary>
    /// Method that verifies logic of correct region name of country 
    /// </summary>
    /// <param name="name">Correct Region name of country </param>
    [Theory]
    [GenericClassData<RegionNameCorrectTestsData>]
    public override void ValidationShouldBeCorrect(string name) => base.ValidationShouldBeCorrect(name);
}