namespace ChallengeN5.Application.Test.Dtos;

public class GetPermissionsDtoTest
{
    [Fact]
    public void DontSetData_Should_Be_Null_When_Is_OK()
    {
        var getPermissionsDto = new GetPermissionsDto();
        Assert.Null(getPermissionsDto.EmployeeId);
        Assert.Null(getPermissionsDto.PermissionTypeId);
    }

    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var getPermissionsDto = new GetPermissionsDto()
        {
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a"
        };

        Assert.NotNull(getPermissionsDto.PermissionTypeId);
        Assert.NotNull(getPermissionsDto.PermissionTypeId);
    }
}
