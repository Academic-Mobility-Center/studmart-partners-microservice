namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class TooLongDescriptionException(string description, int length, int maxLength) : FormatException($"Description {description} is too long ({length}). Description must be less than {maxLength}")
{
    public string Description { get; } = description;
    public int Length { get; } = length;
    public int MaxLength { get; } = maxLength;
}