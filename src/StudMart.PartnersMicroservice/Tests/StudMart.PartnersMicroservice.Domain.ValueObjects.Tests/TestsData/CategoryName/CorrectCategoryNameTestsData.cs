using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CategoryName;

public class CorrectCategoryNameTestsData() : TestsDataBase<string>(ValidCategories)
{
    private static IEnumerable<string> ValidCategories => new List<string>
    {
        "Рестораны",
        "IT-услуги",
        "Образование",
        "Розничные магазины",
        "Финансовые услуги",
        "Туризм и путешествия",
        "Производство",
        "Healthcare", // Латиница
        "E-commerce"  // С дефисом
    };
    
}