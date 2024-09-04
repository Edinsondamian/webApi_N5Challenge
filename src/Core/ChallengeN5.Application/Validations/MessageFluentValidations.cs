namespace ChallengeN5.Application.Validations;

public class MessageFluentValidations : IMessageFluentValidations
{
    private readonly MessageValidation messageValidations;
    public MessageFluentValidations(IOptions<MessageValidation> options)
    {
        messageValidations = options.Value;
    }
    public string GetMessage(string codeMessage)
    {
        return messageValidations.Values[codeMessage].ToString();
    }
    public List<ValidationFailure> GetMessageToValidationFailure(string codeMessage)
    {
        return new List<ValidationFailure>() { new ValidationFailure() { ErrorCode = codeMessage, ErrorMessage = GetMessage(codeMessage) } };
    }
}
