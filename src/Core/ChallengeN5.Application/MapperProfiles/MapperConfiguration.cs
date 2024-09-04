namespace ChallengeN5.Application.MapperProfiles;

public static class MapperConfiguration
{
    public static void AddMapper(this IServiceCollection services)
    {
        var mapper = new AutoMapper.MapperConfiguration(configuration =>
        {
            configuration.AddProfile(new AutoMapperProfile());
        });

        services.AddSingleton(mapper.CreateMapper());
    }
}
