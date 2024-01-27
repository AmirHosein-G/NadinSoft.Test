using Application.Abstractions;
using Domain.Dto.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;

    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string Generate(UserDto user, CancellationToken cancellationToken = default)
    {
        var claims = new Claim[] 
        { 
            new Claim(JwtRegisteredClaimNames.Sub, "2") ,//user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("hsnistheprovider1375secretkeyofhsn")),
            SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;  
    }
}
