using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Phone;

/// <summary>
/// Class that contains incorrect phones to test phone validation logic
/// </summary>
public class IncorrectPhoneTestsData : IEnumerable<object[]>
{
    /// <summary>
    /// Incorrect mobile phone numbers to test validation
    /// </summary>
    private static readonly IEnumerable<object[]> IncorrectPhones =
    [
        ["12345"],
        ["+12345678901234567890"],
        ["+1"],
        ["1234567890"],
        ["+9991234567890"],
        ["+1234567890"],
        ["+1234a567890"],
        ["+1234567"],
        ["+12345678a90"],
        ["+1234567890#1234"]
    ];
    /// <summary>
    /// Enumerator to incorrect phones collection
    /// </summary>
    /// <returns>Enumerator to first incorrect phone into collection</returns>
    public IEnumerator<object[]> GetEnumerator() => IncorrectPhones.GetEnumerator();
    /// <summary>
    /// Enumerator to incorrect phones collection
    /// </summary>
    /// <returns>Enumerator to first incorrect phone into collection</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
}