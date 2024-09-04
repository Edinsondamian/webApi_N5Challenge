namespace ChallengeN5.API.Validations;

public partial class RgxUtils
{
    public static bool ApiKeyValidator(string value) => ApiKeyIsMatch().IsMatch(value);
    public static bool GuidValidator(string value) => GuidIsMatch().IsMatch(value);

    [GeneratedRegex("^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[34][0-9a-fA-F]{3}-[89ab][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$")]
    private static partial Regex GuidIsMatch();

    [GeneratedRegex("^\\d{6}$")]
    private static partial Regex ApiKeyIsMatch();
}
