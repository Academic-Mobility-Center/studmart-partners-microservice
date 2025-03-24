using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.Validators.Base;

public abstract class NameValidatorTestsBase<TValidator, TException>(TValidator validator, string message)
    : ValidatorTestsBase<TValidator, string, TException>(validator, message, exception => exception.Name)
    where TValidator : IValidator<string> where TException : InvalidNameException;
