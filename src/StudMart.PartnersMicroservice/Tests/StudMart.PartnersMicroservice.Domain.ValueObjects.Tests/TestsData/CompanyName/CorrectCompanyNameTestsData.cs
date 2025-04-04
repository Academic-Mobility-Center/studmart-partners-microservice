using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CompanyName;

public class CorrectCompanyNameTestsData() : TestsDataBase<string>(CorrectCompanyNames)
{
    private static IEnumerable<string> CorrectCompanyNames =>
    [
        "My Company", 
        "My Company LLC",
        "My-Company",
        "My Company's",
        "123 Company",
        "ООО Рога и Копыта", 
        "Компания-Мечта" 
    ];
}