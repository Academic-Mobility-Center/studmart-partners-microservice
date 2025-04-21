using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.RegionName;

public class InvalidRegionNameException(string name) : InvalidNameException("Region name", name, "must contains only russian letters and spaces");