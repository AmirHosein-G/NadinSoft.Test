using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entiys;

namespace Infrastructure.WriteRepository;

public class IdentityWriteRepository : IIdentityWriteRepository
{
    public IUnitOfWork UnitOfWork => _context;
    private readonly ApplicationDbContext _context;

    public IdentityWriteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (Convert.ToBoolean(await _context.SaveChangesAsync()))
        { return true; }
        else
        { throw new Exception("Failed to save data"); }
    }

    public async Task<bool> RegisteAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Add(user);
        return await SaveChangesAsync();
    }

    public Task InsertAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
