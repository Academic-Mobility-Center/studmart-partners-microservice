using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Site;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Site;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class SiteValidatorTests() : ValidatorTestsBase<SiteValidator,string,InvalidSiteException>(new SiteValidator(),"Site {0} is incorrect",exception => exception.Site )
{
    /// <summary>
    /// Method that verifies exception if incorrect site given
    /// </summary>
    /// <param name="site">incorrect site address</param>
    [Theory]
    [GenericClassData<IncorrectSiteTestsData>]
    public override void ValidationShouldNotBeCorrect(string site) => base.ValidationShouldNotBeCorrect(site);


    /// <summary>
    /// Method that verifies logic of correct site address of company
    /// </summary>
    /// <param name="site">Correct site address of company</param>
    [Theory]
    [ClassData(typeof(CorrectSiteTestsData))]
    public override void ValidationShouldBeCorrect(string site) => base.ValidationShouldBeCorrect(site);
    
}