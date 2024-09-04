namespace ChallengeN5.API.Test.ErrorResponses;

public class ExceptionDetailResponseFactoryTest
{
    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var exceptionDetailResponseFactory = ExceptionDetailResponseFactory.Create(
            ExceptionDetailCode.CODE_DP0001,
            Components.MICROSERVICE,
            ExceptionDetailCode.CODE_DP0001);

        Assert.NotNull(exceptionDetailResponseFactory.Code);
        Assert.NotNull(exceptionDetailResponseFactory.Component);
        Assert.NotNull(exceptionDetailResponseFactory.Description);
    }
}
