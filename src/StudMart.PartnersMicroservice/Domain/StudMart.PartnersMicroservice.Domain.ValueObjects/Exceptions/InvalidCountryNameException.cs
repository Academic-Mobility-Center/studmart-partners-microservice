using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

/// <summary>
/// Exception that occurs if country name is incorrect
/// </summary>
/// <param name="name">String that is incorrect email</param>
public class InvalidCountryNameException(string name) : InvalidNameException("Country name", name);
