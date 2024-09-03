
namespace ChallengeN5.Infrastructure.Repository.Repositories;

public class PermissionTypeRepository : Repository<PermissionType>, IPermissionTypeRepository
{
    public PermissionTypeRepository(AppDbContext context) : base(context) { }
}
