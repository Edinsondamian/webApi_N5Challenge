namespace ChallengeN5.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddServicesApplication(this IServiceCollection services)
    {
        services.AddMapper();
        services.AddScoped<IMessageFluentValidations, MessageFluentValidations>();
        services.AddScoped<IPermissionService, PermissionService>();
        
        return services;
    }
}
