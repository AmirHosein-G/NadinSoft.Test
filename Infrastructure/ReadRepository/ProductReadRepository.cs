using Domain.Abstractions;
using Domain.Dto.ProductDtos;
using Domain.Entiys;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.ReadRepository;

public class ProductReadRepository : IProductReadRepository
{
    private readonly ApplicationDbContext _context;

    public ProductReadRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> GetProductsAsync(CancellationToken cancellationToken)
    => new List<ProductDto>(await ProductQuery().Select(x => new ProductDto(x)).ToListAsync(cancellationToken));

    public async Task<Product> GetProductAsync(int productId, CancellationToken cancellationToken)
    => await ProductQuery().FirstAsync(x => x.Id == productId, cancellationToken);

    private IQueryable<Product> ProductQuery() => _context.Products;


}
