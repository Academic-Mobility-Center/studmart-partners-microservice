using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Bik;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Bik;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class BikValidatorTests() : ValidatorTestsBase<BikValidator, string, InvalidBikException>(new BikValidator(), "Bik {0} is incorrect", exception => exception.Bik)
{
    /// <summary>
    /// Method that verifies exception if incorrect BIK given
    /// </summary>
    /// <param name="bik">incorrect BIK</param>
    [Theory]
    [GenericClassData<IncorrectBikTestsData>]
    public override void ValidationShouldNotBeCorrect(string bik) => base.ValidationShouldNotBeCorrect(bik);


    /// <summary>
    /// Method that verifies logic of correct BIK of organization
    /// </summary>
    /// <param name="bik">Correct real BIK of organization</param>
    [Theory]
    [GenericClassData<CorrectBikTestsData>]
    public override void ValidationShouldBeCorrect(string bik) => base.ValidationShouldBeCorrect(bik);
    
}