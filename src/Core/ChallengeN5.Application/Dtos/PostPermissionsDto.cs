namespace ChallengeN5.Application.Dtos;

public class PostPermissionsDto
{
    [JsonPropertyName("employeeId")]
    public required string EmployeeId { get; set; }

    [JsonPropertyName("permissionTypeId")]
    public required string PermissionTypeId { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }
}
