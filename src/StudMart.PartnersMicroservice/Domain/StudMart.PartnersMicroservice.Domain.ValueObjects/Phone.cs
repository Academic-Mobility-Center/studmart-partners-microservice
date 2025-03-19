using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;


/// <summary>
/// Class that represents Mobile phone of Employee
/// </summary>
/// <param name="value">Mobile phone number of Employee</param>
public class Phone(string value) : ValueObject<string>(value, new PhoneValidator());