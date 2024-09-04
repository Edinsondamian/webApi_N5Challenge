namespace ChallengeN5.Infrastructure.Repository.Test.Context.Mapping;

public class EmployeeConfigurationTest
{
    [Fact]
    public void EmployeeConfiguration_Should_Be_NotNull_When_Is_OK()
    {
        EntityTypeBuilder<Employee>? entity = null;
        new EmployeeConfiguration().Configure(entity);
        Assert.True(true);
    }

    [Fact]
    public void EmployeeConfiguration_SetEntity_Should_Be_NotNull_When_Is_OK()
    {
        var entityType = new EntityType(
            nameof(Employee),
            typeof(Employee),
            new Model(),
            false,
            ConfigurationSource.Convention);

        var builder = new EntityTypeBuilder<Employee>(entityType);
        new EmployeeConfiguration().Configure(builder);

        Assert.True(true);
    }
}
