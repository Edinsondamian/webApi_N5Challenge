namespace ChallengeN5.Domain.KafkaProducer;

public class PermissionRequest
{
    public string? Id { get; set; }
    public required string NameOperation { get; set; }
}
