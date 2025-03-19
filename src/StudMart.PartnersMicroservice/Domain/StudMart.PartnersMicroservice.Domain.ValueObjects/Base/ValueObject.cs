using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

/// <summary>
/// Class that represents base class of domain value object
/// </summary>
/// <typeparam name="T">Simple type of value object result</typeparam>
public abstract class ValueObject<T> : IEquatable<T>
{
    /// <summary>
    /// Value of domain value object
    /// </summary>
    public T Value { get;  }
    /// <summary>
    /// Constructor to create value type object
    /// </summary>
    /// <param name="value">Value of value type object to validate</param>
    /// <param name="validator">Validator object that helps validate simple type value</param>
    protected ValueObject(T value, IValidator<T> validator)
    {
        validator.Validate(value);
        Value = value;
    }
    /// <summary>
    /// Method to translate object to string
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Value?.ToString() ?? "";
    /// <summary>
    /// Method that verify equity of value objects
    /// </summary>
    /// <param name="other">other value object to verify equity</param>
    /// <returns>True if object are equal otherwise </returns>
    private bool Equals(ValueObject<T> other) => EqualityComparer<T>.Default.Equals(Value, other.Value);
    /// <summary>
    /// Method to count hash sum of value
    /// </summary>
    /// <returns>Hash sum of value</returns>
    public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Value!);
    /// <summary>
    /// Method that verify equity of value objects
    /// </summary>
    /// <param name="other">other value object to verify equity</param>
    /// <returns>True if object are equal otherwise - false</returns>
    public bool Equals(T? other) => Value != null && Value.Equals(other);
    /// <summary>
    /// Operator that validates equity of object
    /// </summary>
    /// <param name="first">first value to compare</param>
    /// <param name="second">second value to compare</param>
    /// <returns>True if objects are the same otherwise false</returns>
    public static bool operator==(ValueObject<T> first, ValueObject<T> second)
    {
        if (ReferenceEquals(first, second))
            return true;
        return first.Value != null && first.Value.Equals(second.Value);
    }
    /// <summary>
    /// Operator that validates not equity of values
    /// </summary>
    /// <param name="first">First value to compare</param>
    /// <param name="second">Second value to compare</param>
    /// <returns>True if objects are different otherwise false</returns>
    public static bool operator!=(ValueObject<T> first, ValueObject<T> second) => !(first==second);
    
    /// <summary>
    /// Method that verify equity of value objects
    /// </summary>
    /// <param name="obj">Object to verify equity with this</param>
    /// <returns>True if object are equal otherwise - false</returns>
    public override bool Equals(object? obj) => obj?.GetType() == GetType() && Equals((ValueObject<T>)obj);
}