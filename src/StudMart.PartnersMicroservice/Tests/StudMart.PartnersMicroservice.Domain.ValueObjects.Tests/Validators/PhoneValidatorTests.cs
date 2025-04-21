using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Phone;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Phone;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

/// <summary>
/// Class that tests logic of phone validation
/// </summary>
public class PhoneValidatorTests() : ValidatorTestsBase<PhoneValidator, string,InvalidPhoneNumberException>(new PhoneValidator(), "Phone {0} is incorrect", exception => exception.Phone)
{
    /// <summary>
    /// Valid mobile phones tests
    /// </summary>
    /// <param name="phone">Correct mobile phone of employee</param>
    [Theory]
    [GenericClassData<CorrectPhoneTestsData>]
    public override void ValidationShouldBeCorrect(string phone) => base.ValidationShouldBeCorrect(phone);

    /// <summary>
    /// Method that validates incorrect mobile phones logic
    /// </summary>
    /// <param name="phone">Incorrect mobile phone</param>
    [Theory]
    [GenericClassData<IncorrectPhoneTestsData>]
    public override void ValidationShouldNotBeCorrect(string phone) => base.ValidationShouldNotBeCorrect(phone);
}