using FluentAssertions;
using ServiceName.Models.Hello;
using ServiceName.Services;
using ServiceName.Services.Interfaces;

namespace ServiceName.Tests.Services;

public class TestServiceTests
{
    private readonly ITestService _testService = new TestService();

    [Theory]
    [InlineData("Стас")]
    [InlineData("Сергей")]
    public async Task Hello_Should_Successful(string name)
    {
        var result = await _testService.Hello(new HelloRequest(name));
        result.Should().NotBeNull();
        result.Answer.Should().Be($"Привет {name}!");
    }

    [Fact]
    public async Task Hello_Should_Throw()
    {
        HelloRequest helloRequest = null!;

        var action = async () => await _testService.Hello(helloRequest);

        var exception = await action.Should().ThrowAsync<ArgumentNullException>();
        exception.And.ParamName.Should().Be(nameof(helloRequest));
    }
}
