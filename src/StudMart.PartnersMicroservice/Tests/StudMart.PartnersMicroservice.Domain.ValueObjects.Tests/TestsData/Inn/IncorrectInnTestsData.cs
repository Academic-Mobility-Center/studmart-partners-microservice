using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;

/// <summary>
/// Class that contains incorrect INNs to test INN validation logic
/// </summary>
public class IncorrectInnTestData : IEnumerable<object[]>
{
    /// <summary>
    /// Incorrect Correct INNs of organizations to test base ValueObject class logic
    /// </summary>
    private static readonly IEnumerable<object[]> IncorrectInns =
    [
        [12345],
        [12345678901],
        [1234567890],
        [12345678901234]
    ];
    /// <summary>
    /// Enumerator to incorrect INNs collection
    /// </summary>
    /// <returns>Enumerator to first element of incorrect INNs collection</returns>
    public IEnumerator<object[]> GetEnumerator() => IncorrectInns.GetEnumerator();
    /// <summary>
    /// Enumerator to incorrect INNs collection
    /// </summary>
    /// <returns>Enumerator to first element of incorrect INNs collection</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}