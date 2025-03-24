using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
/// <summary>
/// Exception that occurs if last name of person is incorrect
/// </summary>
/// <param name="name">String that is incorrect last name</param>
public class InvalidLastNameException(string name) : InvalidNameException("Last name", name);
