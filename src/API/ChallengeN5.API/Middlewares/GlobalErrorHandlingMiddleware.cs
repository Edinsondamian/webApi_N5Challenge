namespace ChallengeN5.API.Middlewares;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(
        HttpContext context,
        IMessageFluentValidations messageFluentValidations,
        IServiceProvider serviceProvider)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(
            context,
                exception,
                messageFluentValidations,
                serviceProvider);
        }
    }

    private static Task HandleExceptionAsync(
        HttpContext context,
        Exception exception,
        IMessageFluentValidations messageFluentValidations,
        IServiceProvider serviceProvider)
    {
        HttpStatusCode status;
        var exceptionType = exception.GetType();

        var error = ErrorResponseBaseFactory.Create(
            ErrorCode.ERROR_CODE_TL9999,
            ErrorCode.ERROR_DESCRIPTION_TL9999,
            ErrorType.TECHNICAL);

        var logger = serviceProvider.GetService<ILogger<GlobalErrorHandlingMiddleware>>();
        bool logException = false;

        if (exceptionType == typeof(EntityNotFoundException))
        {
#nullable disable
            var exceptionDetail = ExceptionDetailResponseFactory.Create(((EntityNotFoundException)exception).Code,
                Components.MICROSERVICE,
                messageFluentValidations.GetMessage(((EntityNotFoundException)exception).Code));
#nullable restore

            status = HttpStatusCode.NotFound;
            error = ErrorResponseBaseFactory.Create(
                ErrorCode.ERROR_CODE_TL0010,
                ErrorCode.ERROR_DESCRIPTION_TL0010,
                ErrorType.FUNCTIONAL,
                new List<ExceptionDetailResponse>() { exceptionDetail });
        }
        else if (exceptionType == typeof(HeaderException<ExceptionDetailResponse>))
        {
            status = HttpStatusCode.BadRequest;
            error = ErrorResponseBaseFactory.Create(
                ErrorCode.ERROR_CODE_TL0003,
                ErrorCode.ERROR_DESCRIPTION_TL0003,
                ErrorType.TECHNICAL,
                (HeaderException<ExceptionDetailResponse>)exception);
        }
        else
        {
            status = HttpStatusCode.InternalServerError;
            logger?.LogError("{exception}", exception.Message);
            logException = true;
        }

        var exceptionResult = System.Text.Json.JsonSerializer.Serialize(
            error,
            new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        if (!logException)
            logger?.LogError("{exception}", exceptionResult);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(exceptionResult);
    }
}
