namespace ChallengeN5.API.Extensions;

public static class ResourceExtensions
{
    public static WebApplicationBuilder AddResourceExtensions(this WebApplicationBuilder webApplicationBuilder)
    {
        var configuration = webApplicationBuilder.Configuration.AddJsonFile("Resources/messages.json", optional: true, reloadOnChange: true).Build();
        webApplicationBuilder.Services.Configure<MessageValidation>(configuration.GetSection("MessageValidation"));
        webApplicationBuilder.Services.Configure<MessageHeader>(configuration.GetSection("MessageHeader"));

        return webApplicationBuilder;
    }
}
