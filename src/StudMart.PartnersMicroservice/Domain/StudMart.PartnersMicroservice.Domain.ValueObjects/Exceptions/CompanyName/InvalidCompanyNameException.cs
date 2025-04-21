using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CompanyName;

public class InvalidCompanyNameException(string name) : InvalidNameException("Company name", name, "contains only russian and english letters, digits and spaces");
