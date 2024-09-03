namespace ChallengeN5.Infrastructure.Repository.Repositories;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(AppDbContext context) : base(context) { }

    public async Task<List<Permission>> GetListAsync(Expression<Func<Permission, bool>> expression)
    {
        return await _entity.AsNoTracking().Where(expression).ToListAsync();
    }
}
