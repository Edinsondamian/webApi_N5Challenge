namespace ChallengeN5.Application.Test.MapperProfiles;

public class MapperConfigurationTest
{
    private readonly AutoMapper.MapperConfiguration _configuration;
    private readonly IMapper _mapper;

    public MapperConfigurationTest()
    {
        _configuration = new AutoMapper.MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new AutoMapperProfile());
        });

        _mapper = _configuration.CreateMapper();
    }

    [Fact]
    public void ShouldBeValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [InlineData(typeof(Employee), typeof(EmployeeDto))]
    public void MapSourceToDestinationExistConfiguration(System.Type origin, System.Type destination)
    {
        var instance = FormatterServices.GetUninitializedObject(origin);
        Assert.NotNull(_mapper.Map(instance, origin, destination));
    }
}
