using ServiceName.Controllers;
using ServiceName.IntegrationTests.WebApplicationFactories;

namespace ServiceName.IntegrationTests;

[CollectionDefinition(nameof(ServiceNameIntegrationTestCollection))]
public class ServiceNameIntegrationTestCollection : ICollectionFixture<ServiceNameWebApplicationFactory<BaseController>>;
