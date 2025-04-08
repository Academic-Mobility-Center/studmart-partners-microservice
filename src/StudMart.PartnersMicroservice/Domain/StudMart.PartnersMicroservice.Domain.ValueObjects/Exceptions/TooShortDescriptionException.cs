namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class TooShortDescriptionException(string description, int length, int minLength) : FormatException($"Description {description} is too short ({length}). Description must be at least {minLength}")
{
    public string Description { get; } = description;
    public int Length { get; } = length;
    public int MinLength { get; } = minLength;
}