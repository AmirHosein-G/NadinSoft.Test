using Domain.Entiys;

namespace Domain.Abstractions;

public interface IProductWriteRepository
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    Task<bool> InsertAsync(Product product, CancellationToken cancellationToken);

}
