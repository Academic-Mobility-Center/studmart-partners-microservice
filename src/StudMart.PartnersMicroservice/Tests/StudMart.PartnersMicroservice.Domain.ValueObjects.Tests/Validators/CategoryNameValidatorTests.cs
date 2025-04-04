using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CategoryName;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Tests.Common.Attributes;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators;

public class CategoryNameValidatorTests()
    : ValidatorTestsBase<CategoryNameValidator, string, InvalidCategoryNameException>(new CategoryNameValidator(),
        "Category name '{0}' is invalid", exception => exception.Name)
{
    [Theory]
    [GenericClassData<CorrectCategoryNameTestsData>]
    public override void ValidationShouldBeCorrect(string value) => base.ValidationShouldBeCorrect(value);
    [Theory]
    [GenericClassData<IncorrectCategoryNameTestsData>]
    public override void ValidationShouldNotBeCorrect(string value) => base.ValidationShouldNotBeCorrect(value);
    
}