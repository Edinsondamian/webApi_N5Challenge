namespace ChallengeN5.Application.Dtos;

public class GetPermissionsDto
{
    [JsonPropertyName("employeeId")]
    public string? EmployeeId { get; set; }

    [JsonPropertyName("permissionTypeId")]
    public string? PermissionTypeId { get; set; }
}
