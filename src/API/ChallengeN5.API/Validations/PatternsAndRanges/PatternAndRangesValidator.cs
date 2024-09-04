namespace ChallengeN5.API.Validations.PatternsAndRanges;

public class PatternAndRangesValidator : IPatternAndRangesValidator
{
    private readonly IMessageUtils _messageUtils;
    private List<ExceptionDetailResponse> _queryErrors;

    public PatternAndRangesValidator(IMessageUtils messageUtils)
    {
        _messageUtils = messageUtils;
        _queryErrors = new();
    }

    public List<ExceptionDetailResponse> IsInvalid(string property, string value, ParamsValidationDto paramsValidationDto)
    {
        if (paramsValidationDto.Pattern != null)
            IsInvalidPattern(property, value, paramsValidationDto);

        IsInvalidRange(value, paramsValidationDto);
        return _queryErrors;
    }

    private void IsInvalidPattern(string property, string value, ParamsValidationDto paramsValidationDto)
    {
#nullable disable
        if (string.Equals(property, "x-api-key", StringComparison.Ordinal))
            if (!RgxUtils.ApiKeyValidator(value))
                _queryErrors.Add(ExceptionDetailResponseFactory.Create(
                    paramsValidationDto.Pattern,
                    Components.MICROSERVICE,
                    _messageUtils.GetMessage(paramsValidationDto.Pattern)));

        if (string.Equals(property, "employeeId", StringComparison.Ordinal) ||
            string.Equals(property, "permissionTypeId", StringComparison.Ordinal))
            if (!RgxUtils.GuidValidator(value))
                _queryErrors.Add(ExceptionDetailResponseFactory.Create(
                    paramsValidationDto.Pattern,
                    Components.MICROSERVICE,
                    _messageUtils.GetMessage(paramsValidationDto.Pattern)));
#nullable restore
    }

    private void IsInvalidRange(string value, ParamsValidationDto paramsValidationDto)
    {
        StringBuilder sb = new(value);
        if (sb.Length < paramsValidationDto.Min || sb.Length > paramsValidationDto.Max)
            _queryErrors.Add(ExceptionDetailResponseFactory.Create(
                paramsValidationDto.Range,
                Components.MICROSERVICE,
                _messageUtils.GetMessage(paramsValidationDto.Range)));
    }
}
