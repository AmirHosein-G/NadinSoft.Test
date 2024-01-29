using Domain.Dto.ProductDtos;
using Domain.Entiys;

namespace Domain.Abstractions;

public interface IProductReadRepository
{
    Task<List<Product>> GetProductsAsync(int? userId, CancellationToken cancellationToken);
    Task<Product> GetProductAsync(int productId, CancellationToken cancellationToken);
}
