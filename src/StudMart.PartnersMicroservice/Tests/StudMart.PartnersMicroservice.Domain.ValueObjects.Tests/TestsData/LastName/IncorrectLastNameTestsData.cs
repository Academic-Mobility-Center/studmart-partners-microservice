using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.LastName;

public class IncorrectLastNameTestsData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _invalidNames =
    [
        [""], // Пустая строка
        ["   "], // Строка с пробелами
        ["Иванов@"], // Некорректная фамилия с символом '@'
        ["Петров$Водкин"], // Некорректная фамилия с символом '$'
        ["123 Сидоров"], // Некорректная фамилия с цифрами
        ["О’Коннор!"] // Некорректная фамилия с символом '!'
    ];

    public IEnumerator<object[]> GetEnumerator() => _invalidNames.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}