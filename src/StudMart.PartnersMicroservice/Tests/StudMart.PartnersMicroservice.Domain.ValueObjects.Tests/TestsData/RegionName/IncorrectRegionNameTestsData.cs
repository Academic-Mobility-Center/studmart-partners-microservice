using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.RegionName;

public class IncorrectRegionNameTestsData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _validNames =
    [
        [""], // Пустая строка
        ["   "], // Строка с пробелами
        ["Московская@область"], // Некорректное название с символом '@'
        ["Санкт-Петербург$"], // Некорректное название с символом '$'
        ["123 Республика Татарстан"], // Некорректное название с цифрами
        ["Краснодарский край!"] // Некорректное название с символом '!'
    ];

    public IEnumerator<object[]> GetEnumerator() => _validNames.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
}