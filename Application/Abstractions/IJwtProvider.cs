using Domain.Dto.Identity;

namespace Application.Abstractions;

public interface IJwtProvider 
{
    string Generate(UserDto user, CancellationToken cancellationToken = default);
}
