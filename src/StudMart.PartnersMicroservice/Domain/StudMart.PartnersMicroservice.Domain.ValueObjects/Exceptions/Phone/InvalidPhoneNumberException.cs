using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Phone;


/// <summary>
/// Exception that occurs if phone number is incorrect
/// </summary>
/// <param name="phone">Incorrect phone number</param>
public class InvalidPhoneNumberException(string phone) : InvalidValueObjectValueFormatExceptionBase("Phone", phone, "be in russian phone format +7XXXXXXXXXX")
{
    /// <summary>
    /// Invalid phone value
    /// </summary>
    public string Phone { get; } = phone;
}