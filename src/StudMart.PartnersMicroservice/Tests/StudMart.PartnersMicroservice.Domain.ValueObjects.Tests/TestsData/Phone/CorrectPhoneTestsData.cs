using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Phone;

/// <summary>
/// Class that contains real correct phones of employees
/// </summary>
public class CorrectPhoneTestsData() : TestsDataBase<string>(CorrectPhones)
{
    /// <summary>
    /// Correct mobile phone numbers to test base SingleParameterValueObjectBase class logic
    /// </summary>
    private static readonly IEnumerable<string> CorrectPhones = 
    [
        "+79833129179",
        "+79139011865",
        "+79139682607"
    ];
}