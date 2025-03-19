using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Email;

/// <summary>
/// Class that contains correct email addresses of employees
/// </summary>
public class CorrectEmailTestsData : IEnumerable<object[]>
{
    
    /// <summary>
    /// Correct emails to validate base class Value object logic
    /// </summary>
    public static readonly IEnumerable<object[]> CorrectEmails =
    [
        ["oleggolen@mail.ru"],
        ["oleg-golenischev63@gmail.com"],
        ["oleggolen@gmail.com"],
        ["test@test.com"]
    ];
    /// <summary>
    /// Enumerator to correct email addresses collection
    /// </summary>
    /// <returns>First element of correct email addresses collection</returns>
    public IEnumerator<object[]> GetEnumerator() => CorrectEmails.GetEnumerator();
    /// <summary>
    /// Enumerator to correct email addresses collection
    /// </summary>
    /// <returns>First element of correct email addresses collection</returns>
    IEnumerator IEnumerable.GetEnumerator() =>GetEnumerator();
}