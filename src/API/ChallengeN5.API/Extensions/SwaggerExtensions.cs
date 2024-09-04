namespace ChallengeN5.API.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddServicesSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ChallengeN5 V1",
                Description = "Componente encargado de administrar clientes, permisos y tipos de permisos.",
                License = new OpenApiLicense
                {
                    Name = "Challenge N5"
                }
            });

            options.OperationFilter<AddRequiredHeaderParameterSwagger>();

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            options.EnableAnnotations();

        });

        return services;
    }
}

