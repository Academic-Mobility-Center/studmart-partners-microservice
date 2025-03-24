using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;


/// <summary>
/// Exception that occurs if phone number is incorrect
/// </summary>
/// <param name="phone">Incorrect phone number</param>
public class InvalidPhoneNumberException(string phone) : InvalidValueObjectValueFormatException("Phone", phone)
{
    /// <summary>
    /// Invalid phone value
    /// </summary>
    public string Phone { get; } = phone;
}