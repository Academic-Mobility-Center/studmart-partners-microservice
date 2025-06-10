using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace StudMart.StudentsMicroservice.Presentation.WebHost.Helpers;

public class HttpXmlRepository(HttpClient httpClient) : IXmlRepository
{
    private const string KeyEndpoint = "/keys";

    public IReadOnlyCollection<XElement> GetAllElements()
    {
        var response = httpClient.GetAsync(KeyEndpoint).Result;

        if (!response.IsSuccessStatusCode)
            return [];

        var bytes = response.Content.ReadAsByteArrayAsync().Result;
        var xml = Encoding.UTF8.GetString(bytes);
        var element = XElement.Parse(xml);

        return [element];
    }

    public void StoreElement(XElement element, string friendlyName)
    {
        var xml = element.ToString(SaveOptions.DisableFormatting);
        var bytes = Encoding.UTF8.GetBytes(xml);

        var content = new ByteArrayContent(bytes);
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

        var response = httpClient.PostAsync(KeyEndpoint, content).Result;
        response.EnsureSuccessStatusCode();
    }
}
