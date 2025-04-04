using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Subtitle;

public class CorrectSubtitleTestsData() : TestsDataBase<string>(ValidSubtitles)
{
    private static IEnumerable<string> ValidSubtitles => new List<string>
    {
        "Сервис доставки",
        "Магазин косметики",
        "Сеть кофеен",
        "IT-компания",
        "Производитель мебели",
        "Банковский сервис",
        "Образовательная платформа",
        "Delivery service",  // Латиница
        "Digital-агентство",  // С дефисом
        "Туры, путешествия"  // С запятой
    };
}