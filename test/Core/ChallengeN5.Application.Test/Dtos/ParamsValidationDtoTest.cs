namespace ChallengeN5.Application.Test.Dtos;

public class ParamsValidationDtoTest
{
    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var paramsValidationDto = new ParamsValidationDto()
        {
            Required = "required",
            Pattern = "pattern",
            Range = "range",
            Min = 1,
            Max = 1
        };

        Assert.NotNull(paramsValidationDto.Required);
        Assert.NotNull(paramsValidationDto.Pattern);
        Assert.NotNull(paramsValidationDto.Range);
    }
}
