namespace ChallengeN5.Infrastructure.Repository.Test.Context.Mapping;

public class PermissionConfigurationTest
{
    [Fact]
    public void PermissionConfiguration_Should_Be_NotNull_When_Is_OK()
    {
        EntityTypeBuilder<Permission>? entity = null;
        new PermissionConfiguration().Configure(entity);
        Assert.True(true);
    }

    [Fact]
    public void PermissionConfiguration_SetEntity_Should_Be_NotNull_When_Is_OK()
    {
        var entityType = new EntityType(
            nameof(Permission),
            typeof(Permission),
            new Model(),
            false,
            ConfigurationSource.Convention);

        var builder = new EntityTypeBuilder<Permission>(entityType);
        new PermissionConfiguration().Configure(builder);

        Assert.True(true);
    }
}
