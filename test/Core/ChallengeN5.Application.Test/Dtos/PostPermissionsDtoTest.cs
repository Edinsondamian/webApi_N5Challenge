namespace ChallengeN5.Application.Test.Dtos;

public class PostPermissionsDtoTest
{
    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var postPermissionsDto = new PostPermissionsDto()
        {
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        Assert.NotNull(postPermissionsDto.EmployeeId);
        Assert.NotNull(postPermissionsDto.PermissionTypeId);
        Assert.NotNull(postPermissionsDto.Description);
    }
}
