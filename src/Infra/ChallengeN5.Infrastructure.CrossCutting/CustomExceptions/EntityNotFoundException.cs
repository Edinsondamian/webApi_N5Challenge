namespace ChallengeN5.Infrastructure.CrossCutting.CustomExceptions;

public class EntityNotFoundException : Exception
{
    public string _code;
    public string? Code => _code;

    public EntityNotFoundException(string code) : base(code) => _code = code;
}
