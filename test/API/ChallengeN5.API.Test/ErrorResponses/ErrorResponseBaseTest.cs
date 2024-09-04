namespace ChallengeN5.API.Test.ErrorResponses;

public class ErrorResponseBaseTest
{
    [Fact]
    public void DontSetData_Should_Be_Null_When_Is_OK()
    {
        var errorResponseBase = new ErrorResponseBase();
        Assert.Empty(errorResponseBase.Code);
        Assert.Empty(errorResponseBase.Description);
        Assert.Empty(errorResponseBase.ErrorType);
        Assert.Null(errorResponseBase.ExceptionDetails);
    }

    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var errorResponseBase = new ErrorResponseBase()
        {
            Code = ErrorCode.ERROR_CODE_TL9999,
            Description = ErrorCode.ERROR_DESCRIPTION_TL9999,
            ErrorType = ErrorType.TECHNICAL,
            ExceptionDetails = new List<ExceptionDetailResponse>()
            {
                new ExceptionDetailResponse()
                {
                    Code = ExceptionDetailCode.CODE_DP0001,
                    Component = Components.MICROSERVICE,
                    Description= ExceptionDetailCode.CODE_DP0001
                }
            }
        };

        Assert.NotNull(errorResponseBase.Code);
        Assert.NotNull(errorResponseBase.Description);
        Assert.NotNull(errorResponseBase.ErrorType);
        Assert.NotNull(errorResponseBase.ExceptionDetails);
        Assert.True(errorResponseBase.ExceptionDetails.Count > 0);
    }
}
