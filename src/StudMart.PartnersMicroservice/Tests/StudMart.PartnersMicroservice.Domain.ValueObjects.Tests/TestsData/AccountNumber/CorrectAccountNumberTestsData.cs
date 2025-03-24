using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.AccountNumber;

public class CorrectAccountNumberTestsData() : TestsDataBase<string>(ValidAccounts)
{
    private static readonly IEnumerable<string> ValidAccounts  =
    [
        "40702810500000000001",  
        "30101810400000000225",  
        "40817810500000000012" 
    ];
    
}