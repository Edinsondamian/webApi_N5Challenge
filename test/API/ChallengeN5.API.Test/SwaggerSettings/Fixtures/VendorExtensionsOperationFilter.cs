namespace ChallengeN5.API.Test.SwaggerSettings.Fixtures;

public class VendorExtensionsOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext contex)
    {
        operation.Extensions.Add("X-property1", new OpenApiString("value"));
    }
}
