namespace ChallengeN5.API;

public static class ServiceExtensions
{
    public static WebApplicationBuilder AddWebApplication(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.AddResourceExtensions();
        return webApplicationBuilder;
    }

    public static IServiceCollection AddServicesApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRouting(x => x.LowercaseUrls = true);
        services.AddHttpContextAccessor();
        services.AddServicesSwagger();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddScoped<IPatternAndRangesValidator, PatternAndRangesValidator>();

        return services;
    }
}
