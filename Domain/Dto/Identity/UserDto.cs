using Domain.Entiys;

namespace Domain.Dto.Identity;

public class UserDto
{
    public UserDto()
    {
            
    }
    public UserDto(User user)
    {
        UserId = user.Id;
        UserName = user.UserName;   
        Password = user.Password;
    }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}
