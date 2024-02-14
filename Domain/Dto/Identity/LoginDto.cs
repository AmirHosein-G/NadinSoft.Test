using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Identity;

public class LoginDto
{
    [Required(ErrorMessage = "User Name is required")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}
