using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

/// <summary>
/// Class that represents email address
/// </summary>
/// <param name="value">Email string</param>
public class Email(string value) : ValueObject<string>(value, new EmailValidator());