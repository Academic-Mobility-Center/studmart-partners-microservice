using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.RegionName;

public class IncorrectRegionNameTestsData() : TestsDataBase<string>(ValidNames)
{
     private static readonly IEnumerable<string> ValidNames =
    [
        "", 
        "   ", 
        "Московская@область", 
        "Санкт-Петербург$", 
        "123 Республика Татарстан", 
        "Краснодарский край!" 
    ];
    
}