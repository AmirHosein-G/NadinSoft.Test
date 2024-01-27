using Domain.Dto.Identity;

namespace Domain.Abstractions;

public interface IIdentityReadRepository
{
    Task<UserDto> GetUserAsync(string username, string password, CancellationToken cancellationToken);
}
