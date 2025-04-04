using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.LastName;

public class CorrectLastNameTestsData() : TestsDataBase<string>(ValidNames)
{
    private static readonly IEnumerable<string> ValidNames = 
    [
        "Иванов", 
        "Петров-Водкин", 
        "Сидорова", 
        "О’Коннор", 
        "Д’Артаньян", 
        "ван Дейк" 
    ];
}