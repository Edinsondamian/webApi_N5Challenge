namespace ChallengeN5.API.Test.SwaggerSettings;

public class AddRequiredHeaderParameterSwaggerTest
{
    [Fact]
    public void AddRequiredHeaderParameterSwagger_Should_Be_NotNull_When_Is_OK()
    {
        var addRequiredHeaderParameterSwagger = new AddRequiredHeaderParameterSwagger();
        Assert.NotNull(addRequiredHeaderParameterSwagger);
    }

    [Fact]
    public void Apply_Should_Be_NotNull_When_Is_OK()
    {
        var operation = new OpenApiOperation();

        var methodInfo = typeof(FakeController).GetMethod(nameof(FakeController.ActionWithSwaggerOperationAttribute));
        var filterContext = new OperationFilterContext(
            apiDescription: null,
            schemaRegistry: null,
            schemaRepository: null,
            methodInfo: methodInfo);

        var addRequiredHeaderParameterSwagger = new AddRequiredHeaderParameterSwagger();
        addRequiredHeaderParameterSwagger.Apply(operation, filterContext);
        Assert.NotNull(addRequiredHeaderParameterSwagger);
    }

    [Fact]
    public void Apply_SetNulls_Should_Be_NotNull_When_Is_OK()
    {
        var operation = new OpenApiOperation
        {
            Parameters = null,
            Security = null
        };

        var methodInfo = typeof(FakeController).GetMethod(nameof(FakeController.ActionWithSwaggerOperationAttribute));
        var filterContext = new OperationFilterContext(
            apiDescription: null,
            schemaRegistry: null,
            schemaRepository: null,
            methodInfo: methodInfo);

        var addRequiredHeaderParameterSwagger = new AddRequiredHeaderParameterSwagger();
        addRequiredHeaderParameterSwagger.Apply(operation, filterContext);
        Assert.NotNull(addRequiredHeaderParameterSwagger);
    }
}
