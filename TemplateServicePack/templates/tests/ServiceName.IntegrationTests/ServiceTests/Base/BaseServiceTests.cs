using System.Text;
using System.Text.Json;
using ServiceName.Controllers;
using ServiceName.IntegrationTests.WebApplicationFactories.Base;
using Xunit.Abstractions;

namespace ServiceName.IntegrationTests.ServiceTests.Base;

public abstract class BaseServiceTests
(
    BaseWebApplicationFactory<BaseController> webApplicationFactory,
    ITestOutputHelper outputHelper
)
{
    protected OpenAPIs.ServiceName PreparedTest()
    {
        var client = webApplicationFactory.CreateClient();
        return new OpenAPIs.ServiceName(client.BaseAddress?.ToString(), client);
    }

    protected async Task<HttpResponseMessage> PreparedTest<T>(T request, string requestUri)
    {
        outputHelper.WriteLine($"Fixture id: {webApplicationFactory.Id}");

        using var client = webApplicationFactory.CreateClient();
        var content = GetContent(request);
        return await client.PostAsync(requestUri, content, CancellationToken.None);
    }

    private static StringContent GetContent<T>(T request)
    => new(JsonSerializer.Serialize(request), mediaType: "application/json", encoding: Encoding.UTF8);
}
