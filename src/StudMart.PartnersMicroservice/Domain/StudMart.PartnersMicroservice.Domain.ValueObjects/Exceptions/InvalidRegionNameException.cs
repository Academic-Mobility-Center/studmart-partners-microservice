using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidRegionNameException(string name) : InvalidNameException("Region name", name);