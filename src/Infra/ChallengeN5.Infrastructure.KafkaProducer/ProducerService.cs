namespace ChallengeN5.Infrastructure.KafkaProducer;

public class ProducerService : IProducerService
{
    private readonly IConfiguration _configuration;
    private readonly IProducer<Null, string> _producer;
    public ProducerService(IConfiguration configuration)
    {
        _configuration = configuration;
        var producerconfig = new ProducerConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"]
        };
        _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
    }

    public async Task ProduceAsync(PermissionRequest permissionRequest)
    {
        permissionRequest.Id = Guid.NewGuid().ToString();
        var serialize = System.Text.Json.JsonSerializer.Serialize(permissionRequest);
        var kafkamessage = new Message<Null, string> { Value = serialize };
        await _producer.ProduceAsync(_configuration["Kafka:topic"], kafkamessage);
    }
}
