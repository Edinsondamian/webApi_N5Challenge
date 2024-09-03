namespace ChallengeN5.Infrastructure.CrossCutting.CustomExceptions;

public class HeaderException<T> : Exception
{
    public IEnumerable<T>? Errors { get; private set; }

    public HeaderException(IEnumerable<T> errors)
    {
        Errors = errors;
    }
}
