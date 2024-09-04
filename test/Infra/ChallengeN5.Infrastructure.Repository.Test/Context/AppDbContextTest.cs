namespace ChallengeN5.Infrastructure.Repository.Test.Context;

public class AppDbContextTest
{
    #region IDisposable Support
    private bool disposedValue = false;

    public AppDbContext CreateContextInMemory(string databaseName)
    {
        var option = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;

        var context = new AppDbContext(option);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        SetContextDatabase(context);
        return context;
    }

    public void Dispose()
    {
        if (!disposedValue)
            disposedValue = true;
    }

    private void SetContextDatabase(AppDbContext context)
    {
        var employee = new Employee()
        {
            Id = "3305d248-49c0-4da0-8e81-d82e6c2e76df",
            Name = "Name"
        };

        var permissionType = new PermissionType()
        {
            Id = "0daac6c7-4862-4560-a992-22187c1e6fd0",
            Permission = "Permission"
        };

        var permission = new Permission()
        {
            Id = "d43813a3-dfd0-46e6-815f-13bb6678dba8",
            EmployeeId = "6273a62b-8373-4d1f-9d7b-769b9c224757",
            PermissionTypeId = "ee74e998-abd7-4374-a8ac-84e41140b96b",
            Description = "Description"
        };

        context.Employees.Add(employee);
        context.PermissionTypes.Add(permissionType);
        context.Permissions.Add(permission);
        context.SaveChanges();
    }
    #endregion IDisposable Support

    [Fact]
    public void AppDbContext_Should_Be_NotNull_When_Is_OK()
    {
        var option = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "AppDbContextTest1")
            .Options;

        var context = new AppDbContext(option);
        Assert.NotNull(context);
    }

    [Fact]
    public void AppDbContext_ChannelsDbSet_Should_Be_NotNull_When_Is_OK()
    {
        var context = CreateContextInMemory("Employee");
        DbSet<Employee> employees = context.Employees;
        Assert.NotNull(employees);
    }

    [Fact]
    public void AppDbContext_ChatbotsDbSet_Should_Be_NotNull_When_Is_OK()
    {
        var context = CreateContextInMemory("PermissionTypes");
        DbSet<PermissionType> permissionTypes = context.PermissionTypes;
        Assert.NotNull(permissionTypes);
    }

    [Fact]
    public void AppDbContext_UsersDbSet_Should_Be_NotNull_When_Is_OK()
    {
        var context = CreateContextInMemory("Permissions");
        DbSet<Permission> permissions = context.Permissions;
        Assert.NotNull(permissions);
    }

    [Fact]
    public void Modify_Should_Be_NotNull_When_Is_OK()
    {
        var option = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "RepositoryModifyPermissions")
            .Options;

        var context = new AppDbContext(option);
        var repository = new Repository<Permission>(context);

        var permission = new Permission()
        {
            Id = "c5dfc0b2-9e2a-4a5a-8b47-c8ccb7e0067a",
            EmployeeId = "526d61fc-d55c-4681-abbd-65a31f1fc603",
            PermissionTypeId = "9fe01cb2-d79c-409b-9e5a-b4ffa60b8d34",
            Description = "Description"
        };

        repository.Modify(permission);

        Assert.NotNull(repository);
    }
}
