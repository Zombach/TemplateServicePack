using ServiceName.Models.Hello;

namespace ServiceName.Services.Interfaces;

public interface ITestService
{
    Task<HelloResponse> Hello(HelloRequest helloRequest, CancellationToken cancellationToken = default);
}
