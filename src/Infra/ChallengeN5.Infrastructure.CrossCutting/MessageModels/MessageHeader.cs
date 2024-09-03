namespace ChallengeN5.Infrastructure.CrossCutting.MessageModels;

public class MessageHeader
{
    public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
}
