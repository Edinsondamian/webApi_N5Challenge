namespace ChallengeN5.API.Test;

public class ServiceExtensionsTest
{
    [Fact]
    public void AddWebApplication_Should_Be_NotNull_When_Is_OK()
    {
        var builder = WebApplication.CreateBuilder(Array.Empty<string>());
        var addWebApplication = ServiceExtensions.AddWebApplication(builder);
        Assert.NotNull(addWebApplication);
    }

    [Fact]
    public void AddServicesApi_Should_Be_NotNull_When_Is_OK()
    {
        var services = new Mock<IServiceCollection>();
        var builder = WebApplication.CreateBuilder(Array.Empty<string>());
        var addWebApplication = ServiceExtensions.AddServicesApi(services.Object, builder.Configuration);
        Assert.NotNull(addWebApplication);
    }
}
