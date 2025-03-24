using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidCompanyNameException(string name) : InvalidNameException("Company name", name);
