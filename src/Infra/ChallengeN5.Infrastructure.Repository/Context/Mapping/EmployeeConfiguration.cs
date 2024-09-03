
namespace ChallengeN5.Infrastructure.Repository.Context.Mapping;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> entity)
    {
        if (entity == null)
            return;

        entity.ToTable("Employee");
        entity.HasKey(e => e.Id).HasName("id");

        entity.Property(e => e.Id)
            .HasMaxLength(36)
            .IsUnicode(false)
            .HasColumnName("id");
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("name");
    }
}