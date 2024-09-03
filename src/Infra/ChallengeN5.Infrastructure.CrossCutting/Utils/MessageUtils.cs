namespace ChallengeN5.Infrastructure.CrossCutting.Utils;

public interface IMessageUtils
{
    string GetMessage(string codeMessage);
}

public class MessageUtils : IMessageUtils
{
    private readonly MessageHeader _messageHeader;

    public MessageUtils(IOptions<MessageHeader> options)
    {
        _messageHeader = options.Value;
    }

    public string GetMessage(string codeMessage)
    {
        return _messageHeader.Values[codeMessage].ToString();
    }
}
