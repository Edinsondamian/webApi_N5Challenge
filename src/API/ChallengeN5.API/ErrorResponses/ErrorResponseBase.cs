namespace ChallengeN5.API.ErrorResponses;

public class ErrorResponseBase
{
    [JsonProperty("code")]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("errorType")]
    public string ErrorType { get; set; } = string.Empty;

    [JsonProperty("exceptionDetails")]
    public List<ExceptionDetailResponse>? ExceptionDetails { get; set; }
}
