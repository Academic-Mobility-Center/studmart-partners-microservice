using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Subtitle;

public class IncorrectSubtitleTestData() : TestsDataBase<string>(InvalidSubtitles)
{
    private static IEnumerable<string> InvalidSubtitles => new List<string>
    {
        "",
        "   ",
        "Слишком длинное описание которое явно превышает лимит в 35 символов",
        "Одинслово",
        "123 компания",  // Цифры
        "Банк!",  // Спецсимвол
        "Сеть @кофеен",  // Недопустимый символ
        "a",  // Слишком короткое
        " ",  // Только пробел
        "Компания-которая-делает-слишком-длинные-подзаголовки"  // Слишком длинное
    };

}