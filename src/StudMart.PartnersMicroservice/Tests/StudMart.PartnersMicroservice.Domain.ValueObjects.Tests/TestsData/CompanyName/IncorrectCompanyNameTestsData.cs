using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CompanyName;

public class IncorrectCompanyNameTestsData() : TestsDataBase<string>(InvalidNames)
{
    private static  readonly IEnumerable<string> InvalidNames = 
    [
        "",
        "   ",
        "My@Company",
        "My$Company",
        "My Company!",
        "Моя@Компания",
        "ООО Рога$Копыта"
    ];
}