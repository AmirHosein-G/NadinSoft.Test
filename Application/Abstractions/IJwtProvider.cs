using Domain.Dto.Identity;
using System.Security.Claims;

namespace Application.Abstractions;

public interface IJwtProvider 
{
    string Generate(List<Claim> claims, CancellationToken cancellationToken = default);
}
