namespace ChallengeN5.Application.Contracts;

public interface IPermissionService
{
    Task<List<PermissionDto>> GetAllPermissions(GetPermissionsDto getPermissionsDto);
    Task<PermissionDto> SavePermission(PostPermissionsDto postPermissionsDto);
    Task<PermissionDto> UpdatePermission(string permissionId, PutPermissionsDto putPermissionsDto);
}
