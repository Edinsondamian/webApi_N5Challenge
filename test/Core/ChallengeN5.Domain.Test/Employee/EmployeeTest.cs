namespace ChallengeN5.Domain.Test.Employee;

public class EmployeeTest
{
    [Fact]
    public void DontSetData_Should_Be_Null_When_Is_OK()
    {
        var employee = new ChallengeN5.Domain.Employee.Employee();
        Assert.Null(employee.Id);
        Assert.Null(employee.Name);
    }

    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var employee = new Domain.Employee.Employee()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a",
            Name = "Name"
        };

        Assert.NotNull(employee.Id);
        Assert.NotNull(employee.Name);
    }
}
