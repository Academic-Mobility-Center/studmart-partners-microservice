using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.CompanyName;

public class InvalidLengthCompanyNameException(int length) : InvalidLengthExceptionBase(
    ValueObjectsLengthRules.MinCompanyNameLength, ValueObjectsLengthRules.MaxCompanyNameLength, length, "Company name")
{
}