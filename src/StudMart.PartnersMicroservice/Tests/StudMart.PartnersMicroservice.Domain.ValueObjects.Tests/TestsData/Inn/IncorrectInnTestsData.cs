using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Inn;

/// <summary>
/// Class that contains incorrect INNs to test INN validation logic
/// </summary>
public class IncorrectInnTestData() : TestsDataBase<long>(IncorrectInns)
{
    /// <summary>
    /// Incorrect Correct INNs of organizations to test base SingleParameterValueObjectBase class logic
    /// </summary>
    private static readonly IEnumerable<long> IncorrectInns =
    [
        12345,
        12345678901,
        1234567890,
        12345678901234
    ];

}