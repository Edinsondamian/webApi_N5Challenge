
namespace ChallengeN5.Infrastructure.KafkaProducer;

public static class ServiceExtensions
{
    public static IServiceCollection AddServicesKafkaProducer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IProducerService, ProducerService>();
        return services;
    }

}