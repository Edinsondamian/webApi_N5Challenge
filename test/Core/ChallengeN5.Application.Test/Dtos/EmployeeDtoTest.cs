namespace ChallengeN5.Application.Test.Dtos;

public class EmployeeDtoTest
{
    [Fact]
    public void SetData_Should_Be_NotNull_When_Is_OK()
    {
        var employee = new EmployeeDto()
        {
            Id = "1e05c935-0246-4c97-88cc-4069d318c45a"
        };

        Assert.NotNull(employee.Id);
    }
}
