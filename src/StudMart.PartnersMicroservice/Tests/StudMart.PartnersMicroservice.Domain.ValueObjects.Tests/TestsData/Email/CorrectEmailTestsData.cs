using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Email;

/// <summary>
/// Class that contains correct email addresses of employees
/// </summary>
public class CorrectEmailTestsData() : TestsDataBase<string>(CorrectEmails)
{
    
    /// <summary>
    /// Correct emails to validate base class Value object logic
    /// </summary>
    private static readonly IEnumerable<string> CorrectEmails =
    [
        "oleggolen@mail.ru",
        "oleg-golenischev63@gmail.com",
        "oleggolen@gmail.com",
        "test@test.com"
    ];

}