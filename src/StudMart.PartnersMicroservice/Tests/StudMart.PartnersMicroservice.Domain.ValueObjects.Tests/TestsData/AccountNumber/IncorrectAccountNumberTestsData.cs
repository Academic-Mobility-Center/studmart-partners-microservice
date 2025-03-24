using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.AccountNumber;

public class IncorrectAccountNumberTestsData() : TestsDataBase<string>(InvalidAccounts)
{
    private static readonly IEnumerable<string> InvalidAccounts =
    [
        null!,                    
        "",                      
        "   ",                  
        "4070281050000000000",  
        "407028105000000000012", 
        "abcdefghijklmnopqrst",  
        "40702 8105 0000 0000 01", 
        "40702-8105-0000-0000-01", 
        "40702.8105.0000.0000.01", 
        "4070281050000000000A"    
    ];
    
}