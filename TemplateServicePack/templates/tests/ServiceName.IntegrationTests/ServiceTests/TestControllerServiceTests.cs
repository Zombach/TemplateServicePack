using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ServiceName.Controllers;
using ServiceName.IntegrationTests.OpenAPIs;
using ServiceName.IntegrationTests.ServiceTests.Base;
using ServiceName.IntegrationTests.WebApplicationFactories;
using Xunit.Abstractions;

namespace ServiceName.IntegrationTests.ServiceTests;

[Collection(nameof(ServiceNameIntegrationTestCollection))]
public class TestControllerServiceTests
(
    ServiceNameWebApplicationFactory<BaseController> webApplicationFactory,
    ITestOutputHelper outputHelper
) : BaseServiceTests(webApplicationFactory, outputHelper)
{
    private const string RequestUri = "/api/test/hello";

    [Fact]
    public async Task Hello_ShouldReturnHelloResponse()
    {
        var serviceName = PreparedTest();
        var result = await serviceName.HelloAsync(new HelloRequest { Name = "Стас" }, CancellationToken.None);
        result.Should().NotBeNull();
        result.Answer.Should().Be("Привет Стас!");
    }

    [Fact]
    public async Task Hello_ShouldReturnHelloResponseV2()
    {
        var response = await PreparedTest(new HelloRequest { Name = "Стас" }, RequestUri);
        response.Should().Match(message => message.StatusCode == HttpStatusCode.OK && message.Version == HttpVersion.Version11);
        var result = await response.Content.ReadFromJsonAsync<HelloResponse>();
        result.Should().NotBeNull();
        result?.Answer.Should().Be("Привет Стас!");
    }

    [Fact]
    public async Task Hello_ShouldThrowArgumentNullException()
    {
        string name = null!;
        var response = await PreparedTest
        (
            new HelloRequest { Name = name },
            RequestUri
        );
        response.Should().Match(message => message.StatusCode == HttpStatusCode.BadRequest && message.Version == HttpVersion.Version11);

        var result = await response.Content.ReadAsStringAsync();
        result.Should().Contain("validation errors");
        result.Should().Contain("The Name field is required.");
    }
}
