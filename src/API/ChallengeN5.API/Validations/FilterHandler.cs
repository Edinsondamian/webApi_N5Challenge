namespace ChallengeN5.API.Validations;

public static class FilterHandler
{
    public static IActionResult ErrorQueryHandler(List<ExceptionDetailResponse> errors)
    {
        ErrorResponseBase errorResponseBaseFactory = ErrorResponseBaseFactory.Create(
            ErrorCode.ERROR_CODE_TL0003,
            ErrorCode.ERROR_DESCRIPTION_TL0003,
            ErrorType.FUNCTIONAL,
            errors
        );

        var jsonResult = new JsonResult(errorResponseBaseFactory)
        {
            StatusCode = StatusCodes.Status400BadRequest,
            ContentType = "application/json"
        };

        var exception = System.Text.Json.JsonSerializer.Serialize(
            jsonResult,
            new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        return jsonResult;
    }
}
