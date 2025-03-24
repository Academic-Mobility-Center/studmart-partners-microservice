using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;

/// <summary>
/// Class that contains correct real INNs of companies
/// </summary>
public class CorrectInnTestsData() : TestsDataBase<long>(CorrectInns)
{
    /// <summary>
    /// Correct INNs of organizations for tests
    /// </summary>
    private static readonly IEnumerable<long> CorrectInns =
    [
        5037011336,
        7701908643,
        7716955847
    ];

}