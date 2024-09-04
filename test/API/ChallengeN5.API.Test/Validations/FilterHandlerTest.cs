namespace ChallengeN5.API.Test.Validations;

public class FilterHandlerTest
{
    [Fact]
    public void FilterHandlerTest_Should_Be_NotNull_When_Is_OK()
    {
        List<ExceptionDetailResponse> errors = new()
        {
            new ExceptionDetailResponse()
            {
                Code = "DP0001",
                Component = Components.MICROSERVICE,
                Description = "Error"
            }
        };

        var filterHandler = FilterHandler.ErrorQueryHandler(errors);
        Assert.NotNull(filterHandler);
    }
}

