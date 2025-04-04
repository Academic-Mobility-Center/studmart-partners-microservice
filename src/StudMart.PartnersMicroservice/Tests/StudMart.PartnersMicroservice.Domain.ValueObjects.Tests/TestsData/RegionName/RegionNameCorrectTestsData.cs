using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.RegionName;

public class RegionNameCorrectTestsData() : TestsDataBase<string>(ValidNames)
{
    private static  readonly IEnumerable<string> ValidNames =
    [
        "Московская область", 
        "Санкт-Петербург", 
        "Республика Татарстан", 
        "Краснодарский край", 
        "Ханты-Мансийский автономный округ" 
    ];
}