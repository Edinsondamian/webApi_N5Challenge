namespace ChallengeN5.Infrastructure.Repository.Test.Context.Mapping;

public class PermissionTypeConfigurationTest
{
    [Fact]
    public void PermissionTypeConfiguration_Should_Be_NotNull_When_Is_OK()
    {
        EntityTypeBuilder<PermissionType>? entity = null;
        new PermissionTypeConfiguration().Configure(entity);
        Assert.True(true);
    }

    [Fact]
    public void PermissionTypeConfiguration_SetEntity_Should_Be_NotNull_When_Is_OK()
    {
        var entityType = new EntityType(
            nameof(PermissionType),
            typeof(PermissionType),
            new Model(),
            false,
            ConfigurationSource.Convention);

        var builder = new EntityTypeBuilder<PermissionType>(entityType);
        new PermissionTypeConfiguration().Configure(builder);

        Assert.True(true);
    }
}
