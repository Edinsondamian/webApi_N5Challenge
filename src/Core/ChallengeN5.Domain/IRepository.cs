namespace ChallengeN5.Domain;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> expression);
    void Modify(TEntity item);
}

