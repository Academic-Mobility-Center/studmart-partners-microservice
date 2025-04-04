using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Subtitle;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class SubtitleValidatorTests()
    : ValidatorTestsBase<SubtitleValidator, string, InvalidSubtitleException>(new SubtitleValidator(),
        "Subtitle {0} is incorrect", exception => exception.Subtitle)
{
    [Theory]
    [GenericClassData<CorrectSubtitleTestsData>]
    public override void ValidationShouldBeCorrect(string value) => base.ValidationShouldBeCorrect(value);
    [Theory]
    [GenericClassData<IncorrectSubtitleTestData>]
    public override void ValidationShouldNotBeCorrect(string value) => base.ValidationShouldNotBeCorrect(value);
    
}