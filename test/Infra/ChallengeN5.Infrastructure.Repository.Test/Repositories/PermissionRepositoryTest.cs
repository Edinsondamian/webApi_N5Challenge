namespace ChallengeN5.Infrastructure.Repository.Test.Repositories;

public class PermissionRepositoryTest
{
    private readonly AppDbContext _contextInMemory;

    public PermissionRepositoryTest()
        => _contextInMemory ??= new AppDbContextTest().CreateContextInMemory("PermissionRepositoryTest");

    [Fact]
    public void PermissionRepository_Should_Be_NotNull_When_Is_OK()
    {
        var permissionRepository = new PermissionRepository(_contextInMemory);
        Assert.NotNull(permissionRepository);
    }

    [Fact]
    public async void PermissionRepository_GetAllAsync_Should_Be_True_When_Is_OK()
    {
        var permissionRepository = new Repository<Permission>(_contextInMemory);
        var result = await permissionRepository.GetAllAsync();

        Assert.True(result.Count > 0);
    }
}
