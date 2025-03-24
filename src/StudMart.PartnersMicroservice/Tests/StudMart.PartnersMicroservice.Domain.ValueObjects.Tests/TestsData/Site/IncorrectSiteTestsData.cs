using StudMart.PartnersMicroservice.Tests.Common.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Tests.TestsData.Site;

public class IncorrectSiteTestsData() : TestsDataBase<string>(InvalidUrls)
{
    private static readonly IEnumerable<string> InvalidUrls =
    [
        "",
        "   ",
        "example",
        "example..com",
        "http://example..com",
        "https://example com",
        "ftp://example.com",
        "example.com/ path",
        "example.com? param=value",
        "javascript:alert(1)",
        "https://example.com/<script>"
    ];
}