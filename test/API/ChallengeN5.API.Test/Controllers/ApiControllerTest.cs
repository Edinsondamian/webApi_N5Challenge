namespace ChallengeN5.API.Test.Controllers;

public class ApiControllerTest
{
    private readonly Mock<IPermissionService> _permissionService;
    private readonly ApiController _apiController;

    public ApiControllerTest()
    {
        _permissionService = new Mock<IPermissionService>();
        _apiController = new ApiController(_permissionService.Object);
    }

    [Fact]
    public async Task GetPermissions_Should_Be_Customer_When_Is_OK()
    {
        var getPermissionsDto = new GetPermissionsDto();

        var permissions = new List<PermissionDto>()
        {
            new()
            {
                Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
                EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
                PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
                Description = "Description"
            }
        };

        _permissionService.Setup(x => x.GetAllPermissions(getPermissionsDto)).ReturnsAsync(permissions);

        var result = await _apiController.GetPermissions(getPermissionsDto);

        var objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        Assert.Equal(permissions, objectResult.Value);
    }

    [Fact]
    public async Task PostPermissions_Should_Be_Customer_When_Is_OK()
    {
        var postPermissionsDto = new PostPermissionsDto()
        {
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        var permissions = new PermissionDto()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        _permissionService.Setup(x => x.SavePermission(postPermissionsDto)).ReturnsAsync(permissions);

        var result = await _apiController.PostPermissions(postPermissionsDto);

        var objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        Assert.Equal(permissions, objectResult.Value);
    }

    [Fact]
    public async Task PutPermissions_Should_Be_Customer_When_Is_OK()
    {
        var putPermissionsDto = new PutPermissionsDto()
        {
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        var permissions = new PermissionDto()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        _permissionService.Setup(x => x.UpdatePermission("1e05c935-0246-4c97-88cc-4069d318c45a", putPermissionsDto)).ReturnsAsync(permissions);

        var result = await _apiController.PutPermissions("1e05c935-0246-4c97-88cc-4069d318c45a", putPermissionsDto);

        var objectResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, objectResult.StatusCode);
        Assert.Equal(permissions, objectResult.Value);
    }
}
