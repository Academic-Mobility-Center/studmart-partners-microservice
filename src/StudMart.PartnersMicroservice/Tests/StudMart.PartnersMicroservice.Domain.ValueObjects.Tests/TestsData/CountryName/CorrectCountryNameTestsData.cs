using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CountryName;

public class CorrectCountryNameTestsData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _validNames =
    [
        ["Россия"], // Корректное название
        ["Южная Корея"], // Корректное название с пробелами
        ["Кот-д’Ивуар"], // Корректное название с апострофом
        ["Соединенные Штаты Америки"], // Корректное название с пробелами
        ["Северная Македония"] // Корректное название с пробелами
    ];

    public IEnumerator<object[]> GetEnumerator() => _validNames.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}