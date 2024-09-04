namespace ChallengeN5.API.SwaggerSettings;

public class AddRequiredHeaderParameterSwagger : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = [];

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "api-key",
            In = ParameterLocation.Header,
            Required = true
        });

        if (operation.Security == null)
            operation.Security = [];

        var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
        operation.Security.Add(new OpenApiSecurityRequirement
        {
            [scheme] = []
        });
    }
}
