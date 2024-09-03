namespace ChallengeN5.Infrastructure.Repository.Context.Mapping;
public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
{
    public void Configure(EntityTypeBuilder<PermissionType> entity)
    {
        if (entity == null)
            return;

        entity.ToTable("PermissionType");
        entity.HasKey(e => e.Id).HasName("id");

        entity.Property(e => e.Id)
            .HasMaxLength(36)
            .IsUnicode(false)
            .HasColumnName("id");
        entity.Property(e => e.Permission)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("permission");
    }
}
