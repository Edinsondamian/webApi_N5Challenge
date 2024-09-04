namespace ChallengeN5.API.ErrorResponses;

public class ExceptionDetailResponse
{
    [JsonProperty("code")]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("component")]
    public string Component { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;
}
