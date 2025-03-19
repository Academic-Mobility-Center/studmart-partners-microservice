using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Phone;

/// <summary>
/// Class that contains real correct phones of employees
/// </summary>
public class CorrectPhoneTestsData : IEnumerable<object[]>
{
    /// <summary>
    /// Correct mobile phone numbers to test base ValueObject class logic
    /// </summary>
    public static readonly IEnumerable<object[]> CorrectPhones = 
    [
        ["+79833129179"],
        ["+79139011865"],
        ["+79139682607"]
    ];
    /// <summary>
    /// Enumerator to correct phones collection
    /// </summary>
    /// <returns>Enumerator to first collect phone</returns>
    public IEnumerator<object[]> GetEnumerator() => CorrectPhones.GetEnumerator();
    /// <summary>
    /// Enumerator to correct phones collection
    /// </summary>
    /// <returns>Enumerator to first collect phone</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}