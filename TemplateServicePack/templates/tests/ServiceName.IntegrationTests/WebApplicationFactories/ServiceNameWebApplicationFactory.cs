using ServiceName.IntegrationTests.WebApplicationFactories.Base;

namespace ServiceName.IntegrationTests.WebApplicationFactories;

public class ServiceNameWebApplicationFactory<TEntryPoint>
    : BaseWebApplicationFactory<TEntryPoint>
    where TEntryPoint : class;
