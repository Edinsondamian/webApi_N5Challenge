namespace ChallengeN5.Infrastructure.Repository.Test;

public class ServiceExtensionsTest
{
    private readonly IConfiguration _configuration;

    public ServiceExtensionsTest()
    {
        var inMemorySettings = new Dictionary<string, string?>()
        {
            { "ConnectionStrings:BDCONSTR", "client" }
        };

        _configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
    }

    [Fact]
    public void AddServicesInfrastructurePersistence_Should_Be_NotNull_When_Is_OK()
    {
        var services = new ServiceCollection();
        services.AddScoped<AppDbContext>();

        var addWebApplication = ServiceExtensions.AddServicesInfrastructurePersistence(services, _configuration);

        Assert.NotNull(addWebApplication);
    }

    [Fact]
    public void GetDatabaseConnectionString_Should_Be_NotNull_When_Is_OK()
    {
        var methodInfo = typeof(ServiceExtensions).GetMethod("GetDatabaseConnectionString", BindingFlags.Static | BindingFlags.NonPublic);
        var token = methodInfo?.Invoke(null, new object[] { _configuration });

        Assert.Equal(_configuration["ConnectionStrings:BDCONSTR"], token);
    }

    [Fact]
    public void GetDatabaseConnectionString_Should_Be_Throw_NotNull_When_Is_OK()
    {
        var configuration = new Mock<IConfiguration>();

        var methodInfo = typeof(ServiceExtensions).GetMethod("GetDatabaseConnectionString", BindingFlags.Static | BindingFlags.NonPublic);
        Assert.Throws<TargetInvocationException>(() => methodInfo?.Invoke(null, new object[] { configuration.Object }));
    }
}
