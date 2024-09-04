namespace ChallengeN5.Application.Test.Dtos;

public class PutPermissionsDtoTest
{
    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var putPermissionsDto = new PutPermissionsDto()
        {
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        Assert.NotNull(putPermissionsDto.PermissionTypeId);
        Assert.NotNull(putPermissionsDto.Description);
    }
}
