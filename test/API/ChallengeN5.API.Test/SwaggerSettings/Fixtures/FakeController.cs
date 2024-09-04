namespace ChallengeN5.API.Test.SwaggerSettings.Fixtures;

[SwaggerOperationFilter(typeof(VendorExtensionsOperationFilter))]
[SwaggerResponse(500, "Description for 500 response", typeof(IDictionary<string, string>))]
[SwaggerTag("Description for FakeControllerWithSwaggerAnnotations", "http://tempuri.org")]
internal class FakeController
{
    [SwaggerOperation("Summary for ActionWithSwaggerOperationAttribute",
        Description = "Description for ActionWithSwaggerOperationAttribute",
        OperationId = "actionWithSwaggerOperationAttribute",
        Tags = new[] { "foobar" }
    )]
    public static void ActionWithSwaggerOperationAttribute()
    { }
}
