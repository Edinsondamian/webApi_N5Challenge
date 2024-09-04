namespace ChallengeN5.Domain.Test.Permission;

public class PermissionTest
{
    [Fact]
    public void DontSetData_Should_Be_Null_When_Is_OK()
    {
        var permission = new ChallengeN5.Domain.Permission.Permission();
        Assert.Null(permission.Id);
        Assert.Null(permission.EmployeeId);
        Assert.Null(permission.PermissionTypeId);
        Assert.Null(permission.Description);
    }

    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var permissionType = new Domain.Permission.Permission()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        Assert.NotNull(permissionType.Id);
        Assert.NotNull(permissionType.EmployeeId);
        Assert.NotNull(permissionType.PermissionTypeId);
        Assert.NotNull(permissionType.Description);
    }
}
