namespace ChallengeN5.Infrastructure.CrossCutting;

public static class ServiceExtensions
{
    public static IServiceCollection AddServicesCrossCutting(this IServiceCollection services)
    {
        services.AddScoped<IMessageUtils, MessageUtils>();
        return services;
    }
}
