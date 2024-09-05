namespace ChallengeN5.Domain.KafkaProducer;

public interface IProducerService
{
    Task ProduceAsync(PermissionRequest permissionRequest);
}