using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CountryName;

public class IncorrectCountryNameTestsData() : TestsDataBase<string>(InvalidNames)
{
    private static readonly IEnumerable<string> InvalidNames = 
    [
        "", 
        "   ", 
        "Россия@", 
        "Южная$Корея", 
        "123 Страна", 
        "Кот-д’Ивуар!" 
    ];

}