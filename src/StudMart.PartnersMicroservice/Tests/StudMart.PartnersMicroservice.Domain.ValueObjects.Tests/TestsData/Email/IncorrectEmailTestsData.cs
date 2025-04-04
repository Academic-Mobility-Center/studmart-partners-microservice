using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Email;

/// <summary>
/// Class that contains incorrect emails to test email validation logic
/// </summary>
public class IncorrectEmailTestData() : TestsDataBase<string>(IncorrectEmails)
{
    /// <summary>
    /// Incorrect Emails to test email validation
    /// </summary>
    private static readonly IEnumerable<string> IncorrectEmails =
    [
        "example.com",
        "example@", 
        " example@example.com ", 
        "example\\@example.com", 
        "@example.com",
        "example@@example.com", 
        "example@example.c", 
        "example@.com", 
        "example@examplecom"
    ];

    
}