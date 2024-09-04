namespace ChallengeN5.API.Test.ErrorResponses;

public class ErrorResponseBaseFactoryTest
{
    [Fact]
    public void ExceptionDetailResponse_Should_Be_ErrorResponse_When_Is_OK()
    {
        var code = ErrorCode.ERROR_CODE_TL9999;
        var description = ErrorCode.ERROR_DESCRIPTION_TL9999;
        var errorType = ErrorType.TECHNICAL;
        var exceptionDetails = new List<ExceptionDetailResponse>()
        {
            new ExceptionDetailResponse()
            {
                Code = ExceptionDetailCode.CODE_DP0001,
                Component = Components.MICROSERVICE,
                Description= ExceptionDetailCode.CODE_DP0001
            }
        };

        var errorResponseBaseFactory = ErrorResponseBaseFactory.Create(
            code,
            description,
            errorType,
            exceptionDetails);

        Assert.NotNull(errorResponseBaseFactory.Code);
        Assert.NotNull(errorResponseBaseFactory.Description);
        Assert.NotNull(errorResponseBaseFactory.ErrorType);
        Assert.NotNull(errorResponseBaseFactory.ExceptionDetails);
        Assert.True(errorResponseBaseFactory.ExceptionDetails.Count > 0);
    }

    [Fact]
    public void HeaderException_Should_Be_ErrorResponse_When_Is_OK()
    {
        var code = ErrorCode.ERROR_CODE_TL9999;
        var description = ErrorCode.ERROR_DESCRIPTION_TL9999;
        var errorType = ErrorType.TECHNICAL;

        var errorList = new List<ExceptionDetailResponse>()
        {
            new ExceptionDetailResponse()
            {
                Code = ExceptionDetailCode.CODE_DP0001,
                Component = Components.MICROSERVICE,
                Description= ExceptionDetailCode.CODE_DP0001
            }
        };

        var exception = new HeaderException<ExceptionDetailResponse>(errorList);

        var errorResponseBaseFactory = ErrorResponseBaseFactory.Create(
            code,
            description,
            errorType,
            exception);

        Assert.NotNull(errorResponseBaseFactory.Code);
        Assert.NotNull(errorResponseBaseFactory.Description);
        Assert.NotNull(errorResponseBaseFactory.ErrorType);
        Assert.NotNull(errorResponseBaseFactory.ExceptionDetails);
        Assert.True(errorResponseBaseFactory.ExceptionDetails.Count > 0);
    }
}
