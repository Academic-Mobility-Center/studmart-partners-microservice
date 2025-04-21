using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.Subtitle;

public class InvalidSubtitleException(string title) : InvalidValueObjectValueFormatExceptionBase("Subtitle", title, "contains letters, digits and spaces")
{
    public string Subtitle { get; } = title;
}