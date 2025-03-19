using System.Collections;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Email;

/// <summary>
/// Class that contains incorrect emails to test email validation logic
/// </summary>
public class IncorrectEmailTestData : IEnumerable<object[]>
{
    /// <summary>
    /// Incorrect Emails to test email validation
    /// </summary>
    private static readonly IEnumerable<object[]> IncorrectEmails =
    [
        ["example.com"], ["example@"], [" example@example.com "], ["example\\@example.com"], ["@example.com"],
        ["example@@example.com"], ["example@example.c"], ["example@.com"], ["example@examplecom"]
    ];
    /// <summary>
    /// Enumerator to collection with incorrect email
    /// </summary>
    /// <returns>First element of collection with incorrect emails</returns>
    public IEnumerator<object[]> GetEnumerator() => IncorrectEmails.GetEnumerator();
    /// <summary>
    /// Enumerator to collection with incorrect email
    /// </summary>
    /// <returns>First element of collection with incorrect emails</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
}