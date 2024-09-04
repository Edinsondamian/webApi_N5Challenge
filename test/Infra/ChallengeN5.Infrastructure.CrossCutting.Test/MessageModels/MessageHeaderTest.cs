namespace ChallengeN5.Infrastructure.CrossCutting.Test.MessageModels;

public class MessageHeaderTest
{
    [Fact]
    public void MessageHeader_Should_Be_NotNull_When_Is_OK()
    {
        var messageHeader = new MessageHeader
        {
            Values = new Dictionary<string, string>()
            {
                { "test", "test" }
            }
        };

        Assert.True(messageHeader.Values.ContainsKey("test"));
    }
}
