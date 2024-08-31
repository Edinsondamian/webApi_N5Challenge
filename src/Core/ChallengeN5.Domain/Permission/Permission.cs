namespace ChallengeN5.Domain.Permission;

public partial class Permission
{
    public string Id { get; set; } = null!;
    public string EmployeeId { get; set; } = null!;
    public string PermissionTypeId { get; set; } = null!;
    public string? Description { get; set; }
}
