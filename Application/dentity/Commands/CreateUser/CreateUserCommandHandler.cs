using Domain.Entiys;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.dentity.Commands.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly UserManager<IdentityUser> _userManager;

    public CreateUserCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByNameAsync(command.User.UserName);
        if (userExists != null)
            throw new Exception(message: "User already exists!");

        IdentityUser user = new()
        {
            Email = command.User.Password,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = command.User.UserName
        };
        var result = await _userManager.CreateAsync(user, command.User.Password);
        if (!result.Succeeded)
            throw new Exception( message:"User creation failed! Please check user details and try again." );

        return true;
    }
}

