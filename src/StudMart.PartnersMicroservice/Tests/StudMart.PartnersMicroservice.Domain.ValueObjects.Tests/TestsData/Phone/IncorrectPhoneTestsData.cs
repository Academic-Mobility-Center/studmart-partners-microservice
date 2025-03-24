using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Phone;

/// <summary>
/// Class that contains incorrect phones to test phone validation logic
/// </summary>
public class IncorrectPhoneTestsData() : TestsDataBase<string>(IncorrectPhones)
{
    /// <summary>
    /// Incorrect mobile phone numbers to test validation
    /// </summary>
    private static readonly IEnumerable<string> IncorrectPhones =
    [
        "12345",
        "+12345678901234567890",
        "+1",
        "1234567890",
        "+9991234567890",
        "+1234567890",
        "+1234a567890",
        "+1234567",
        "+12345678a90",
        "+1234567890#1234"
    ];
}