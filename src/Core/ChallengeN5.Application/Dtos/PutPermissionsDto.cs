namespace ChallengeN5.Application.Dtos;

public class PutPermissionsDto
{
    [JsonPropertyName("permissionTypeId")]
    public required string PermissionTypeId { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }
}
