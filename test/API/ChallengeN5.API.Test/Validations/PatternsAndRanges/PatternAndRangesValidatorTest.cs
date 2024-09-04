namespace ChallengeN5.API.Test.Validations.PatternsAndRanges;

public class PatternAndRangesValidatorTest
{
    [Fact]
    public void PatternAndRangesValidator_Should_Be_NotNull_When_Is_OK()
    {
        var messageUtils = new Mock<IMessageUtils>();

        var patternAndRangesValidator = new PatternAndRangesValidator(messageUtils.Object);

        Assert.NotNull(patternAndRangesValidator);
    }

    [Fact]
    public void PatternAndRangesValidator_IsValidEmployeeId_Should_Be_NotNull_When_Is_OK()
    {
        var messageUtils = new Mock<IMessageUtils>();
        var patternAndRangesValidator = new PatternAndRangesValidator(messageUtils.Object);
        var pattern = new ParamsValidationDto()
        {
            Required = ExceptionDetailCode.CODE_MH0004,
            Pattern = ExceptionDetailCode.CODE_MH0005,
            Range = ExceptionDetailCode.CODE_MH0006,
            Min = 36,
            Max = 36
        };

        var result = patternAndRangesValidator.IsInvalid("employeeId", "42ce0891-9add-49bb-8eb2-fa02a671d76a", pattern);

        Assert.False(result.Any());
    }

    [Fact]
    public void PatternAndRangesValidator_IsValidApiKey_Should_Be_NotNull_When_Is_OK()
    {
        var messageUtils = new Mock<IMessageUtils>();
        var patternAndRangesValidator = new PatternAndRangesValidator(messageUtils.Object);
        var pattern = new ParamsValidationDto()
        {
            Required = ExceptionDetailCode.CODE_MH0001,
            Pattern = ExceptionDetailCode.CODE_MH0002,
            Range = ExceptionDetailCode.CODE_MH0003,
            Min = 6,
            Max = 6
        };

        var result = patternAndRangesValidator.IsInvalid("x-api-key", "123456", pattern);

        Assert.False(result.Any());
    }
}
