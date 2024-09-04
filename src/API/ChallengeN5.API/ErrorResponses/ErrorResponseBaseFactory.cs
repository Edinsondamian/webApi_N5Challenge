namespace ChallengeN5.API.ErrorResponses;

public class ErrorResponseBaseFactory
{
    public static ErrorResponseBase Create(
            string code,
            string description,
            string errorType,
            List<ExceptionDetailResponse>? exceptionDetails = null)
    {
        return new ErrorResponseBase
        {
            Code = code,
            Description = description,
            ErrorType = errorType,
            ExceptionDetails = exceptionDetails
        };
    }

    public static ErrorResponseBase Create(
        string code,
        string description,
        string errorType,
        HeaderException<ExceptionDetailResponse> exception)
    {
#nullable disable
        return new ErrorResponseBase
        {
            Code = code,
            Description = description,
            ErrorType = errorType,
            ExceptionDetails = exception.Errors.ToList()
        };
#nullable restore
    }
}
