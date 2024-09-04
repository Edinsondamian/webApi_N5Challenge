namespace ChallengeN5.Infrastructure.CrossCutting.Test.Utils;

public class MessageUtilsTest
{
    [Fact]
    public void GetMessage_Should_Be_NotNull_When_Is_OK()
    {
        var code = "MH0001";
        var message = "El header Authorization es requerido.";

        var messageHeader = new MessageHeader()
        {
            Values = { { code, message } }
        };

        var options = new Mock<IOptions<MessageHeader>>();
        options.Setup(x => x.Value).Returns(messageHeader);

        var messageUtils = new MessageUtils(options.Object);

        var result = messageUtils.GetMessage(code);

        Assert.Equal(result, message);
    }
}
