namespace ChallengeN5.Infrastructure.CrossCutting.Test;

public class ServiceExtensionsTest
{
    [Fact]
    public void AddServicesInfrastructureExternal_Should_Be_NotNull_When_Is_OK()
    {
        var services = new Mock<IServiceCollection>();
        var addWebApplication = ServiceExtensions.AddServicesCrossCutting(services.Object);
        Assert.NotNull(addWebApplication);
    }
}
