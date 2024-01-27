using Application.Abstractions;
using Domain.Abstractions;
using Domain.Dto.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ReadRepository;

public class IdentityReadRepository: IIdentityReadRepository
{
    public IUnitOfWork UnitOfWork => _context;
    private readonly ApplicationDbContext _context;

    public IdentityReadRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> GetUserAsync(string username, string password, CancellationToken cancellationToken) =>
        new UserDto()
        {
            UserName = username,
            Password = password
        };

    //public async Task<UserDto> GetUserAsync(string username, string password, CancellationToken cancellationToken)=>
    //    new UserDto(
    //        await _context.Users.FirstAsync(x => x.UserName == username && x.Password == password, cancellationToken));
}
