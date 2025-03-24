using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.FirstName;

public class CorrectFirstNameTestsData() : TestsDataBase<string>
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