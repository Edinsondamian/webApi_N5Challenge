namespace ChallengeN5.API.Test.Extensions;

public class MiddlewareExtensionsTest
{
    [Fact]
    public void MiddlewareExtensions_Should_Be_NotNull_When_Is_OK()
    {
        var applicationBuilder = new ApplicationBuilder(new Mock<IServiceProvider>().Object);
        applicationBuilder.AddGlobalErrorHandler();
        applicationBuilder.Build();

        var addGlobalErrorHandler = MiddlewareExtensions.AddGlobalErrorHandler(applicationBuilder);

        Assert.NotNull(addGlobalErrorHandler);
    }
}
