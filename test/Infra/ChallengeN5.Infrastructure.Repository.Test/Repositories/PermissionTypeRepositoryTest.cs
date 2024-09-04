namespace ChallengeN5.Infrastructure.Repository.Test.Repositories;

public class PermissionTypeRepositoryTest
{
    private readonly AppDbContext _contextInMemory;

    public PermissionTypeRepositoryTest()
        => _contextInMemory ??= new AppDbContextTest().CreateContextInMemory("PermissionTypeRepositoryTest");

    [Fact]
    public void PermissionTypeRepository_Should_Be_NotNull_When_Is_OK()
    {
        var permissionTypeRepository = new PermissionTypeRepository(_contextInMemory);
        Assert.NotNull(permissionTypeRepository);
    }

    [Fact]
    public async void PermissionTypeRepository_GetAllAsync_Should_Be_True_When_Is_OK()
    {
        var permissionTypeRepository = new Repository<PermissionType>(_contextInMemory);
        var result = await permissionTypeRepository.GetAllAsync();

        Assert.True(result.Count > 0);
    }
}
