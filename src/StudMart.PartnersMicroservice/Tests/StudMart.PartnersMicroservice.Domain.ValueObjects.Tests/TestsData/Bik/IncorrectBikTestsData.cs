using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Bik;

public class IncorrectBikTestsData() : TestsDataBase<string>(InvalidBiks)
{
    private static readonly IEnumerable<string> InvalidBiks =
    [
        "",           // Пустая строка
        "   ",        // Пробелы
        "12345678",   // 8 цифр
        "1234567890", // 10 цифр
        "abcdefghi",  // Буквы
        "123 456 78", // Пробелы между цифр
        "12345-678",  // Дефис
        "123.456.78", // Точки
        "04452522A"   // Буква в конце
    ];
}