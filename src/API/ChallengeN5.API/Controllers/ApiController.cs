namespace ChallengeN5.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public ApiController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet("permissions")]
    public async Task<IActionResult> GetPermissions([FromQuery] GetPermissionsDto getPermissionsDto)
    {
        var permissions = await _permissionService.GetAllPermissions(getPermissionsDto);
        return Ok(permissions);
    }

    [HttpPost("permissions")]
    [TypeFilter(typeof(PostPermissionFilter))]
    public async Task<IActionResult> PostPermissions([FromBody] PostPermissionsDto postGetPermissionsDto)
    {
        var permission = await _permissionService.SavePermission(postGetPermissionsDto);
        return Ok(permission);
    }

    [HttpPut("permissions/{permissionId}")]
    [TypeFilter(typeof(PutPermissionFilter))]
    public async Task<IActionResult> PutPermissions(string permissionId, [FromBody] PutPermissionsDto putPermissionsDto)
    {
        var permission = await _permissionService.UpdatePermission(permissionId, putPermissionsDto);
        return Ok(permission);
    }
}
