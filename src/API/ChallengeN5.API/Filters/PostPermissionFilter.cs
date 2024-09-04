namespace ChallengeN5.API.Filters;

public class PostPermissionFilter : IAsyncAuthorizationFilter
{
    private readonly IMessageUtils _messageUtils;
    private readonly IPatternAndRangesValidator _patternAndRangesValidator;
    private readonly HttpContext? _httpContext;

    public PostPermissionFilter(
        IMessageUtils messageUtils,
        IPatternAndRangesValidator patternAndRangesValidator,
        IHttpContextAccessor httpContextAccessor)
    {
        _messageUtils = messageUtils;
        _patternAndRangesValidator = patternAndRangesValidator;
        _httpContext = httpContextAccessor.HttpContext;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        _httpContext?.Request?.EnableBuffering();

        var bodyStream = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8);
        var body = await bodyStream.ReadToEndAsync();
        List<ExceptionDetailResponse> bodyErrors = [];

        if (string.IsNullOrEmpty(body))
        {
            bodyErrors.Add(ExceptionDetailResponseFactory.Create(
                ExceptionDetailCode.CODE_MH0004,
                Components.MICROSERVICE,
                _messageUtils.GetMessage(ExceptionDetailCode.CODE_MH0004)));
            
            context.Result = FilterHandler.ErrorQueryHandler(bodyErrors);
            return;
        }

        PostPermissionsDto postPermissionsDto;
        try
        {
            postPermissionsDto = JsonConvert.DeserializeObject<PostPermissionsDto>(body);
        }
        catch (Exception)
        {
            bodyErrors.Add(ExceptionDetailResponseFactory.Create(
                ExceptionDetailCode.CODE_MH0004,
                Components.MICROSERVICE,
                _messageUtils.GetMessage(ExceptionDetailCode.CODE_MH0004)));

            context.Result = FilterHandler.ErrorQueryHandler(bodyErrors);
            return;
        }

        if (string.IsNullOrEmpty(postPermissionsDto.EmployeeId))
        {
            bodyErrors.Add(ExceptionDetailResponseFactory.Create(
                ExceptionDetailCode.CODE_MH0005,
                Components.MICROSERVICE,
                _messageUtils.GetMessage(ExceptionDetailCode.CODE_MH0005)));

            context.Result = FilterHandler.ErrorQueryHandler(bodyErrors);
            return;
        }

        if (string.IsNullOrEmpty(postPermissionsDto.PermissionTypeId))
        {
            bodyErrors.Add(ExceptionDetailResponseFactory.Create(
                ExceptionDetailCode.CODE_MH0008,
                Components.MICROSERVICE,
                _messageUtils.GetMessage(ExceptionDetailCode.CODE_MH0008)));

            context.Result = FilterHandler.ErrorQueryHandler(bodyErrors);
            return;
        }

        bodyErrors = _patternAndRangesValidator.IsInvalid(
            "employeeId",
            postPermissionsDto.EmployeeId,
            new ParamsValidationDto()
            {
                Required = ExceptionDetailCode.CODE_MH0005,
                Pattern = ExceptionDetailCode.CODE_MH0006,
                Range = ExceptionDetailCode.CODE_MH0007,
                Min = 36,
                Max = 36
            });

        if (bodyErrors.Any())
        {
            context.Result = FilterHandler.ErrorQueryHandler(bodyErrors);
            return;
        }

        bodyErrors = _patternAndRangesValidator.IsInvalid(
            "permissionTypeId",
            postPermissionsDto.PermissionTypeId,
            new ParamsValidationDto()
            {
                Required = ExceptionDetailCode.CODE_MH0008,
                Pattern = ExceptionDetailCode.CODE_MH0009,
                Range = ExceptionDetailCode.CODE_MH0010,
                Min = 36,
                Max = 36
            });

        if (bodyErrors.Any())
        {
            context.Result = FilterHandler.ErrorQueryHandler(bodyErrors);
            return;
        }

        _httpContext.Request.Body.Position = 0;
    }
}
