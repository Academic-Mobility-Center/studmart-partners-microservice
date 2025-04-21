using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.AccountNumber;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.AccountNumber;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class AccountNumberValidatorTests() : ValidatorTestsBase<AccountNumberValidator,string,InvalidAccountNumberException>(new AccountNumberValidator(), "Account number {0} is incorrect", exception => exception.AccountNumber)
{
    /// <summary>
    /// Method thar verifies exception if incorrect account number given
    /// </summary>
    /// <param name="number">incorrect account number</param>
    [Theory]
    [GenericClassData<IncorrectAccountNumberTestsData>]
    public override void ValidationShouldNotBeCorrect(string number) => base.ValidationShouldNotBeCorrect(number);


    /// <summary>
    /// Method that verifies logic of correct account number addresses 
    /// </summary>
    /// <param name="number">Correct account number </param>
    [Theory]
    [GenericClassData<CorrectAccountNumberTestsData>]
    public override void ValidationShouldBeCorrect(string number) => base.ValidationShouldBeCorrect(number);
}