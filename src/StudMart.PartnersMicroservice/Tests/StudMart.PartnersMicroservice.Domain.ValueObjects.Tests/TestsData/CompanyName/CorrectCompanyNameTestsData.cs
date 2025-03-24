using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CompanyName;

public class CorrectCompanyNameTestsData : IEnumerable<object[]>
{
    private static IEnumerable<object[]> CorrectComanyNames =>
    [
        ["My Company"], 
        ["My Company LLC"],
        ["My-Company"],
        ["My Company's"],
        ["123 Company"],
        ["ООО Рога и Копыта"], 
        ["Компания-Мечта"] 

    ];
    public IEnumerator<object[]> GetEnumerator() => CorrectComanyNames.GetEnumerator();


    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}