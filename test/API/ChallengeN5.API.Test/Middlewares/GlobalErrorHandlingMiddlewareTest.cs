namespace ChallengeN5.API.Test.Middlewares;

public class GlobalErrorHandlingMiddlewareTest
{
    [Fact]
    public async void InvokeAsync_All_Correct_Should_Be_Ok_When_Is_OK()
    {
        var globalErrorHandlingMiddleware = new GlobalErrorHandlingMiddleware(next: (HttpContext context) =>
        {
            return Task.CompletedTask;
        });

        var httpContext = new DefaultHttpContext();
        var messageFluentValidations = new Mock<IMessageFluentValidations>();
        var serviceProvider = new Mock<IServiceProvider>();

        await globalErrorHandlingMiddleware.InvokeAsync(httpContext, messageFluentValidations.Object, serviceProvider.Object);
        Assert.Equal(StatusCodes.Status200OK, httpContext.Response.StatusCode);
    }

    [Fact]
    public async void EntityNotFoundException_Should_Be_Throw_When_Is_OK()
    {
        var globalErrorHandlingMiddleware = new GlobalErrorHandlingMiddleware(next: (HttpContext context) =>
        {
            throw new EntityNotFoundException("EntityNotFoundException");
        });

        var httpContext = new DefaultHttpContext();
        var messageFluentValidations = new Mock<IMessageFluentValidations>();
        var serviceProvider = new Mock<IServiceProvider>();

        await globalErrorHandlingMiddleware.InvokeAsync(httpContext, messageFluentValidations.Object, serviceProvider.Object);
        Assert.Equal(StatusCodes.Status404NotFound, httpContext.Response.StatusCode);
    }

    [Fact]
    public async void HeaderException_Should_Be_Throw_When_Is_OK()
    {
        var errorList = new List<ExceptionDetailResponse>
        {
            ExceptionDetailResponseFactory.Create("ERROR", Components.MICROSERVICE, "ERROR")
        };

        var globalErrorHandlingMiddleware = new GlobalErrorHandlingMiddleware(next: (HttpContext context) =>
        {
            throw new HeaderException<ExceptionDetailResponse>(errorList);
        });

        var httpContext = new DefaultHttpContext();
        var messageFluentValidations = new Mock<IMessageFluentValidations>();
        var serviceProvider = new Mock<IServiceProvider>();

        await globalErrorHandlingMiddleware.InvokeAsync(httpContext, messageFluentValidations.Object, serviceProvider.Object);
        Assert.Equal(StatusCodes.Status400BadRequest, httpContext.Response.StatusCode);
    }

    [Fact]
    public async void Exception_Should_Be_Throw_When_Is_OK()
    {
        var globalErrorHandlingMiddleware = new GlobalErrorHandlingMiddleware(next: (HttpContext context) =>
        {
            throw new Exception("Exception");
        });

        var httpContext = new DefaultHttpContext();
        var messageFluentValidations = new Mock<IMessageFluentValidations>();
        var serviceProvider = new Mock<IServiceProvider>();

        await globalErrorHandlingMiddleware.InvokeAsync(httpContext, messageFluentValidations.Object, serviceProvider.Object);
        Assert.Equal(StatusCodes.Status500InternalServerError, httpContext.Response.StatusCode);
    }
}
