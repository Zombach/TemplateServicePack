using ServiceName.Models.Hello;
using ServiceName.Services.Interfaces;

namespace ServiceName.Services;

public sealed class TestService : ITestService
{
    public Task<HelloResponse> Hello(HelloRequest helloRequest, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(helloRequest);

        return Task.FromResult(new HelloResponse($"Привет {helloRequest.Name}!"));
    }
}
