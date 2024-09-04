namespace ChallengeN5.API.Test.Validations;

public class RgxUtilsTest
{
    [Fact]
    public void ApiKeyValidator_Should_Be_True_When_Is_OK()
    {
        var rg = RgxUtils.ApiKeyValidator("123456");
        Assert.True(rg);
    }

    [Fact]
    public void GuidValidator_Should_Be_True_When_Is_OK()
    {
        var rg = RgxUtils.GuidValidator("31d2d3af-2543-4cc1-99fc-5895f6e22271");
        Assert.True(rg);
    }
}
