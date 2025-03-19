namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

/// <summary>
/// Interface that helps validate simple type values of ValueObjects
/// </summary>
/// <typeparam name="T">Simple type of value object</typeparam>
public interface IValidator<in T>
{
    /// <summary>
    /// Method that validates simple type value of ValueObject
    /// </summary>
    /// <param name="value">Simple type value to validate</param>
    public void Validate(T value);
}