namespace ChallengeN5.API.Middlewares;

public class HeaderHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public HeaderHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(
        HttpContext context,
        IMessageUtils messageUtils,
        IPatternAndRangesValidator patternAndRangesValidator)
    {
        Dictionary<string, string> headers = new()
        {
            { HeadersRequired.X_API_KEY, ExceptionDetailCode.CODE_MH0001}
        };

        List<ExceptionDetailResponse> headerErrors = new();
        foreach (var header in headers)
        {
            if (!context.Request.Headers.ContainsKey(header.Key) || string.IsNullOrEmpty(context.Request.Headers[header.Key]))
            {
                headerErrors.Add(ExceptionDetailResponseFactory.Create(
                    header.Value,
                    Components.MICROSERVICE,
                    messageUtils.GetMessage(header.Value)));
            }
        }

        if (headerErrors.Count > 0)
            throw new HeaderException<ExceptionDetailResponse>(headerErrors);

        Dictionary<string, ParamsValidationDto> headersToValidate = new()
        {
            {
                HeadersRequired.X_API_KEY,
                new ParamsValidationDto()
                {
                    Required = ExceptionDetailCode.CODE_MH0001,
                    Pattern = ExceptionDetailCode.CODE_MH0002,
                    Range = ExceptionDetailCode.CODE_MH0003,
                    Min = 6,
                    Max = 6
                }
            }
        };

#nullable disable
        foreach (var header in headersToValidate)
        {
            headerErrors = patternAndRangesValidator.IsInvalid(
                 header.Key,
                 context.Request.Headers[header.Key],
                 header.Value);
        }
#nullable restore

        if (headerErrors.Any())
            throw new HeaderException<ExceptionDetailResponse>(headerErrors);

        await _next(context);
    }
}
