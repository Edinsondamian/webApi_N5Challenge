namespace ChallengeN5.API.ErrorResponses;

public class ExceptionDetailResponseFactory
{
    public static ExceptionDetailResponse Create(string code, string component, string description)
    {
        return new ExceptionDetailResponse
        {
            Code = code,
            Component = component,
            Description = description
        };
    }
}
