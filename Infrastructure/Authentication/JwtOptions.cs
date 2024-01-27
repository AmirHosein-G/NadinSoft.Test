namespace Infrastructure.Authentication;

public class JwtOptions
{
    public string Issuer { get; init; } = "http://localhost:5124/";
    public string Audience { get; init; } = "http://localhost:5124/";
    public string SecretKey { get; init; } = "hsnistheprovider1375secretkeyofhsn";
}
