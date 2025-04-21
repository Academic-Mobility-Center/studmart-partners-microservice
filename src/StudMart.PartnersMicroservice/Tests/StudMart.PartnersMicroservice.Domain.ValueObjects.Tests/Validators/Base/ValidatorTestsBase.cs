using System.Linq.Expressions;
using FluentAssertions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;
using StudMart.PartnersMicroservice.Tests.Common.Helpers;


namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;

public abstract class ValidatorTestsBase<TValidator, TValidation, TException>(
    TValidator validator,
    string message,
    Expression<Func<TException, TValidation>> propertyExpression)
    where TValidator : IValidator<TValidation>
    where TException : InvalidValueObjectValueFormatExceptionBase
{
    private readonly TValidator _validator = validator;
    
    public virtual void ValidationShouldBeCorrect(TValidation value) =>
        FluentActions.Invoking(() => _validator.Validate(value)).Should().NotThrow();

    public virtual void ValidationShouldNotBeCorrect(TValidation value)
    {
        var result = string.Format(message, value);
        var exception = FluentActions.Invoking(() => _validator.Validate(value)).Should().Throw<TException>()
            .WithMessage(result).Which;
        var incorrectValue = exception.GetPropertyValue(propertyExpression);
        incorrectValue.Should().Be(value);
        
    }
}