using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;

/// <summary>
/// Class that contains correct real INNs of companies
/// </summary>
public class CorrectInnTestsData : IEnumerable<object[]>
{
    /// <summary>
    /// Correct INNs of organizations for tests
    /// </summary>
    public static readonly IEnumerable<object[]> CorrectInns =
    [
        [5037011336],
        [7701908643],
        [7716955847]
    ];
    /// <summary>
    /// Enumerator to correct INNs collection
    /// </summary>
    /// <returns>Enumerator to first element of INNs collections</returns>
    public IEnumerator<object[]> GetEnumerator() => CorrectInns.GetEnumerator();
    /// <summary>
    /// Enumerator to correct INNs collection
    /// </summary>
    /// <returns>Enumerator to first element of INNs collections</returns>
    IEnumerator IEnumerable.GetEnumerator() =>GetEnumerator();
}