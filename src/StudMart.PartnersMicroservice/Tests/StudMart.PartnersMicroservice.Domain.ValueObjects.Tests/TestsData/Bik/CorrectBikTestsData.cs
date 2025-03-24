using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Bik;

public class CorrectBikTestsData() : TestsDataBase<string>(CorrectBiks)
{
    private static readonly IEnumerable<string> CorrectBiks =
    [
        "044525225",  // Корректный БИК
        "123456789",  // Корректный БИК
        "987654321"   // Корректный БИК
    ];

}