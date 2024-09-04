namespace ChallengeN5.Application.Test.Fixtures;

public class AutomapperFixture
{
    public IMapper Mapper { get; set; }

    public AutomapperFixture()
    {
        var mockMapper = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        });
        Mapper = mockMapper.CreateMapper();
    }
}
