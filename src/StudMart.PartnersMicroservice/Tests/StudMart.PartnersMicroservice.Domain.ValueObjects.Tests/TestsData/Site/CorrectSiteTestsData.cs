using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Site;

public class CorrectSiteTestsData() : TestsDataBase<string>(ValidUrls)
{
    private static readonly IEnumerable<string> ValidUrls =
    [
        "https://example.com",
        "http://example.com",
        "www.example.com",
        "example.com",
        "sub.example.com",
        "example.com/path",
        "example.com/path/to/page.html",
        "example.com?param=value",
        "https://example.com:8080",
        "http://localhost",
        "https://россия.рф"
    ];
}