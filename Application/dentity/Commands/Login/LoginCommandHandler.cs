using Application.Abstractions;
using Domain.Abstractions;
using Domain.Dto.Identity;
using Domain.Entiys;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Application.dentity.Commands.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponce>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<IdentityUser> _userManager;

    public LoginCommandHandler(
        IJwtProvider jwtProvider,
        UserManager<IdentityUser> userManager)

    {
        _jwtProvider = jwtProvider;
        _userManager = userManager;
    }

    public async Task<LoginResponce> Handle(LoginCommand query, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(query.UserName);
        if (user != null && await _userManager.CheckPasswordAsync(user, query.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, "2") ,//user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            string token = _jwtProvider.Generate(claims, cancellationToken);

            await _userManager.UpdateAsync(user);

            return new LoginResponce(token);
        }
        throw new Exception("InvalidUser");
    }

}
