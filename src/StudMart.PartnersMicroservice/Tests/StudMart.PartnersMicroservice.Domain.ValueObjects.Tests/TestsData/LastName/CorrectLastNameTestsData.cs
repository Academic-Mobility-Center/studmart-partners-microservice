using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.LastName;

public class CorrectLastNameTestsData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _validNames = 
    [
        ["Иванов"], // Корректная фамилия
        ["Петров-Водкин"], // Корректная фамилия с дефисом
        ["Сидорова"], // Корректная фамилия
        ["О’Коннор"], // Корректная фамилия с апострофом (U+0027)
        ["Д’Артаньян"], // Корректная фамилия с апострофом (U+2019)
        ["ван Дейк"] // Корректная фамилия с пробелом
    ];

    public IEnumerator<object[]> GetEnumerator() => _validNames.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}