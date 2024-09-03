namespace ChallengeN5.Infrastructure.Repository.Context.Mapping;
public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> entity)
    {
        if (entity == null)
            return;

        entity.ToTable("Permission");
        entity.HasKey(e => e.Id).HasName("id");
        entity.HasIndex(e => e.EmployeeId, "employeeId");
        entity.HasIndex(e => e.PermissionTypeId, "permissionTypeId");

        entity.Property(e => e.Id)
            .HasMaxLength(36)
            .IsUnicode(false)
            .HasColumnName("id");
        entity.Property(e => e.Description)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("description");
        entity.Property(e => e.EmployeeId)
            .HasMaxLength(36)
            .IsUnicode(false)
            .HasColumnName("employeeId");
        entity.Property(e => e.PermissionTypeId)
            .HasMaxLength(36)
            .IsUnicode(false)
            .HasColumnName("permissionTypeId");
    }
}
