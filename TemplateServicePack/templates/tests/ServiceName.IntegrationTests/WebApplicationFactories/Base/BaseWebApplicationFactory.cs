using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ServiceName.IntegrationTests.WebApplicationFactories.Base;

public abstract class BaseWebApplicationFactory<TEntryPoint>
: WebApplicationFactory<TEntryPoint>
where TEntryPoint : class
{
    public readonly string Id = Guid.NewGuid().ToString();

    //protected readonly Mock<IDbContext> DbContextFake = new(MockBehavior.Strict);

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            //services.Replace(new ServiceDescriptor(typeof(IDbContext), DbContextFake.Object));
        });
    }
}
