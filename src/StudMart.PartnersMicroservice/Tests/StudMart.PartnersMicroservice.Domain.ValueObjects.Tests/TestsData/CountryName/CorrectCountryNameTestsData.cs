using System.Collections;
using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.CountryName;

public class CorrectCountryNameTestsData() : TestsDataBase<string>(ValidNames)
{
    private static readonly IEnumerable<string> ValidNames =
    [
        "Россия", // Корректное название
        "Южная Корея", // Корректное название с пробелами
        "Кот-д’Ивуар", // Корректное название с апострофом
        "Соединенные Штаты Америки", // Корректное название с пробелами
        "Северная Македония" // Корректное название с пробелами
    ];
}