using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

/// <summary>
/// Exception that occurs if first name of person is incorrect
/// </summary>
/// <param name="name">String that is incorrect first name</param>
public class InvalidFirstNameException(string name) : InvalidNameException("First name", name);
