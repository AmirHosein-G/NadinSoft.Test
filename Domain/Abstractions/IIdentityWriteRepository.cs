using Domain.Entiys;

namespace Domain.Abstractions;

public interface IIdentityWriteRepository
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);

    Task InsertAsync(User user, CancellationToken cancellationToken);

}
