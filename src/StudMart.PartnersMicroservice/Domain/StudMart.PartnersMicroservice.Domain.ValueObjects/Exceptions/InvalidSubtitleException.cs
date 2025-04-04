using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidSubtitleException(string title) : InvalidValueObjectValueFormatException("Subtitle", title)
{
    public string Subtitle { get; } = title;
}