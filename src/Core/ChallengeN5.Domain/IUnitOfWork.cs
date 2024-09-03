namespace ChallengeN5.Domain;
public interface IUnitOfWork
{
    Task<int> CommitAsync();
}
