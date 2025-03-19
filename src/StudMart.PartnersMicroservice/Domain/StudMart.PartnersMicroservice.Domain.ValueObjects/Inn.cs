using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

/// <summary>
/// Class that represents INN information
/// </summary>
/// <param name="value">Integer number that represents INN value of Company</param>
public class Inn(long value) : ValueObject<long>(value, new InnValidator());