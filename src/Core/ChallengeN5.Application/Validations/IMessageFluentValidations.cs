namespace ChallengeN5.Application.Validations;

public interface IMessageFluentValidations
{
    string GetMessage(string codeMessage);
    List<ValidationFailure> GetMessageToValidationFailure(string codeMessage);
}
