namespace ChallengeN5.API.Test.Extensions;

public class SwaggerExtensionsTest
{
    [Fact]
    public void AddServicesSwagger_Should_Be_NotNull_When_Is_OK()
    {
        var services = new Mock<IServiceCollection>();

        var addServicesSwagger = SwaggerExtensions.AddServicesSwagger(services.Object);

        Assert.NotNull(addServicesSwagger);
    }
}
