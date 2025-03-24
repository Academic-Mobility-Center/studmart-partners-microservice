using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.LastName;

public class IncorrectLastNameTestsData() : TestsDataBase<string>(InvalidNames)
{
    private static readonly IEnumerable<string> InvalidNames =
    [
        "", 
        "Иванов@", 
        "Петров$Водкин", 
        "123 Сидоров", 
        "О’Коннор!" 
    ];
    
}