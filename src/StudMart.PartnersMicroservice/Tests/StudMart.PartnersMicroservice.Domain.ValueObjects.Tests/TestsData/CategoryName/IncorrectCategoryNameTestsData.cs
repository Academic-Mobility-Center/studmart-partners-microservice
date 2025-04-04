using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CategoryName;

public class IncorrectCategoryNameTestsData() : TestsDataBase<string>(InvalidCategories)
{
    private static IEnumerable<string> InvalidCategories => new List<string>
    {
        null!,
        "",
        "   ",
        "Слишком длинное название категории которое превышает лимит в пятьдесят символов",
        "IT", // Слишком короткое
        "Банк!", // Спецсимвол
        "123 Компании", // Цифры
        "Кафе & Рестораны", // Недопустимый символ
        " - ", // Только разделители
        "Туризм/Путешествия" // Недопустимый символ
    };
    
}