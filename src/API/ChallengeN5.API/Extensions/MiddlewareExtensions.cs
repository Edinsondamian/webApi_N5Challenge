namespace ChallengeN5.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        applicationBuilder.UseMiddleware<HeaderHandlingMiddleware>();

        return applicationBuilder;
    }
}
