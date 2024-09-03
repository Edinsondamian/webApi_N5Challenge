namespace ChallengeN5.Domain.Permission;

public interface IPermissionRepository : IRepository<Permission>
{
    Task<List<Permission>> GetListAsync(Expression<Func<Permission, bool>> expression);
}