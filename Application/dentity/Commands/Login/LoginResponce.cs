namespace Application.dentity.Commands.Login;

public class LoginResponce
{
    public LoginResponce(string token) => Token = token;

    public string Token { get; set; } = string.Empty;
}
