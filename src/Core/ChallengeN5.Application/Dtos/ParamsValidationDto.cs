namespace ChallengeN5.Application.Dtos;

public class ParamsValidationDto
{
    public required string Required { get; set; }
    public string? Pattern { get; set; }
    public required string Range { get; set; }
    public required int Min { get; set; }
    public required int Max { get; set; }
}
