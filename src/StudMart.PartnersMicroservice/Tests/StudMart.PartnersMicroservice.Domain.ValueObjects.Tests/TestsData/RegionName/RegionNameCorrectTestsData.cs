using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.RegionName;

public class RegionNameCorrectTestsData : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _validNames =
    [
        ["Московская область"], // Корректное название региона
        ["Санкт-Петербург"], // Корректное название региона с дефисом
        ["Республика Татарстан"], // Корректное название региона
        ["Краснодарский край"], // Корректное название региона
        ["Ханты-Мансийский автономный округ"] // Корректное название региона с дефисом
    ];

    public IEnumerator<object[]> GetEnumerator() => _validNames.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}