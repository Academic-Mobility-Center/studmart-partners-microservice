using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CountryName;

public class IncorrectCountryNameTestsData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _invalidNames = 
    [
        [""], // Пустая строка
        ["   "], // Строка с пробелами
        ["Россия@"], // Некорректное название с символом '@'
        ["Южная$Корея"], // Некорректное название с символом '$'
        ["123 Страна"], // Некорректное название с цифрами
        ["Кот-д’Ивуар!"] // Некорректное название с символом '!'
    ];

    public IEnumerator<object[]> GetEnumerator() => _invalidNames.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}