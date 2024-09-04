namespace ChallengeN5.Application.Test.Dtos;

public class PermissionDtoTest
{
    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var permissionDto = new PermissionDto()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        Assert.NotNull(permissionDto.Id);
        Assert.NotNull(permissionDto.EmployeeId);
        Assert.NotNull(permissionDto.PermissionTypeId);
        Assert.NotNull(permissionDto.Description);
    }
}
