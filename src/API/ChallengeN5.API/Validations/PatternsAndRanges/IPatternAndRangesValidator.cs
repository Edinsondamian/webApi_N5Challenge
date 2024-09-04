namespace ChallengeN5.API.Validations.PatternsAndRanges;

public interface IPatternAndRangesValidator
{
    List<ExceptionDetailResponse> IsInvalid(string property, string value, ParamsValidationDto paramsValidationDto);
}
