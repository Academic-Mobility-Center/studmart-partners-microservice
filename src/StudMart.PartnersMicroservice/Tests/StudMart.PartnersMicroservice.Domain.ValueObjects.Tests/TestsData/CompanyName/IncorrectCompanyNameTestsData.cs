using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CompanyName;

public class IncorrectCompanyNameTestsData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _invalidNames = 
    [

        [""],
        ["   "],
        ["My@Company"],
        ["My$Company"],
        ["My Company!"],
        ["Моя@Компания"],
        ["ООО Рога$Копыта"]
    ];

    public IEnumerator<object[]> GetEnumerator() => _invalidNames.GetEnumerator();

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
}