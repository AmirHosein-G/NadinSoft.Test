namespace Application.dentity.Queries.GetUser;

public class LoginResponce
{
    public LoginResponce(string token) => Token = token;

    public string Token{ get; set; } = string.Empty;
}
