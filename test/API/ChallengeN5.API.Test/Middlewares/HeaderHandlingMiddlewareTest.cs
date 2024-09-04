namespace ChallengeN5.API.Test.Middlewares;

public class HeaderHandlingMiddlewareTest
{
    private readonly Mock<IMessageUtils> _messageUtils;
    private readonly Mock<IPatternAndRangesValidator> _patternAndRangesValidator;

    public HeaderHandlingMiddlewareTest()
    {
        _messageUtils = new Mock<IMessageUtils>();
        _patternAndRangesValidator = new Mock<IPatternAndRangesValidator>();
    }

#nullable disable
    [Fact]
    public async void InvokeAsync_Empty_Headers_Should_Be_DontPass_When_Is_OK()
    {
        var headerHandlingMiddleware = new HeaderHandlingMiddleware(next: (HttpContext context) =>
        {
            return Task.CompletedTask;
        });

        var httpContext = new DefaultHttpContext();

        var exception = await Assert.ThrowsAsync<HeaderException<ExceptionDetailResponse>>(
            async () => await headerHandlingMiddleware.InvokeAsync(
                httpContext,
                _messageUtils.Object,
                _patternAndRangesValidator.Object));

        Assert.True(exception.Errors.Any());
    }

    [Fact]
    public async void InvokeAsync_Data_Doesnt_Match_Should_Be_DontPass_When_Is_OK()
    {
        var headerHandlingMiddleware = new HeaderHandlingMiddleware(next: (HttpContext context) =>
        {
            return Task.CompletedTask;
        });

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[HeadersRequired.X_API_KEY] = "123456";

        var messageUtils = new Mock<IMessageUtils>();
        messageUtils.Setup(x => x.GetMessage(ExceptionDetailCode.CODE_MH0001)).Returns("Error");

        _patternAndRangesValidator.Setup(x => x.IsInvalid(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<ParamsValidationDto>()))
            .Returns(new List<ExceptionDetailResponse>()
            {
                new()
                {
                    Code = "code",
                    Component = "component",
                    Description = "description"
                }
            });

        var exception = await Assert.ThrowsAsync<HeaderException<ExceptionDetailResponse>>(
            async () => await headerHandlingMiddleware.InvokeAsync(
                httpContext,
                _messageUtils.Object,
                _patternAndRangesValidator.Object));

        Assert.True(exception.Errors.Any());
    }
#nullable restore
}
