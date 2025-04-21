using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.RegionName;

public class InvalidLengthRegionNameException(int length) : InvalidLengthExceptionBase(
    ValueObjectsLengthRules.MinRegionNameLength, ValueObjectsLengthRules.MaxRegionNameLength, length, "Region name");