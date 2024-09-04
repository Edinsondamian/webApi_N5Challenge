namespace ChallengeN5.Domain.Test.PermissionType;

public class PermissionTypeTest
{
    [Fact]
    public void DontSetData_Should_Be_Null_When_Is_OK()
    {
        var permissionType = new ChallengeN5.Domain.PermissionType.PermissionType();
        Assert.Null(permissionType.Id);
        Assert.Null(permissionType.Permission);
    }

    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var permissionType = new Domain.PermissionType.PermissionType()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Permission = "Permission"
        };

        Assert.NotNull(permissionType.Id);
        Assert.NotNull(permissionType.Permission);
    }
}
