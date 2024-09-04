namespace ChallengeN5.Application.Dtos;

public class PermissionDto
{
    public required string Id { get; set; }
    public required string EmployeeId { get; set; }
    public required string PermissionTypeId { get; set; }
    public string? Description { get; set; }
}
