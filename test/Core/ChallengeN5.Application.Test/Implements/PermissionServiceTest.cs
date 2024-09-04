using ChallengeN5.Application.Dtos;

namespace ChallengeN5.Application.Test.Implements;

public class PermissionServiceTest : IClassFixture<AutomapperFixture>
{
    private readonly AutomapperFixture _mapperFixture;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IPermissionRepository> _permissionRepository;
    private readonly Mock<IEmployeeRepository> _employeeRepository;
    private readonly Mock<IPermissionTypeRepository> _permissionTypeRepository;

    public PermissionServiceTest(AutomapperFixture mapperFixture)
    {
        _mapperFixture = mapperFixture;
        _unitOfWork = new Mock<IUnitOfWork>();
        _permissionRepository = new Mock<IPermissionRepository>();
        _employeeRepository = new Mock<IEmployeeRepository>();
        _permissionTypeRepository = new Mock<IPermissionTypeRepository>();
    }

    [Fact]
    public async Task GetAllPermissions_Should_Be_Permission_When_Is_OK()
    {
        var getPermissionsDto = new GetPermissionsDto()
        {
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a"
        };

        var permissions = new List<Permission>()
        {
            new()
            {
                Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
                EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
                PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
                Description = "Description"
            }
        };

        _permissionRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(permissions);

        var permissionService = new PermissionService(
            _mapperFixture.Mapper,
            _unitOfWork.Object,
            _permissionRepository.Object,
            _employeeRepository.Object,
            _permissionTypeRepository.Object);

        var result = await permissionService.GetAllPermissions(getPermissionsDto);

        Assert.NotNull(result.Any());
    }

    [Fact]
    public async Task SavePermission_Should_Be_Permission_When_Is_OK()
    {
        var postPermissionsDto = new PostPermissionsDto()
        {
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        var permission = new Permission()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            EmployeeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            PermissionTypeId = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Description = "Description"
        };

        var employee = new Employee()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Name = "Name"
        };

        var permissionType = new PermissionType()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Permission = "Permission"
        };

        _employeeRepository.Setup(x => x.GetFirstAsync(x => x.Id == postPermissionsDto.EmployeeId)).ReturnsAsync(employee);
        _permissionTypeRepository.Setup(x => x.GetFirstAsync(x => x.Id == postPermissionsDto.PermissionTypeId)).ReturnsAsync(permissionType);
        _permissionRepository.Setup(x => x.AddAsync(permission));

        var permissionService = new PermissionService(
            _mapperFixture.Mapper,
            _unitOfWork.Object,
            _permissionRepository.Object,
            _employeeRepository.Object,
            _permissionTypeRepository.Object);

        var result = await permissionService.SavePermission(postPermissionsDto);

        Assert.NotNull(result);
    }
}
