using Domain.Abstractions;
using Domain.Dto.ProductDtos;
using Domain.Entiys;
using Mapster;
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

    public async Task<List<Product>> GetProductsAsync(int? userId, CancellationToken cancellationToken)
    {
        return userId switch
        {
            null => await ProductQuery()
                        .Where(x => !x.Deleted).ToListAsync(cancellationToken),
            _ => await ProductQuery()
            .Where(x => x.UserId == userId && !x.Deleted).ToListAsync(cancellationToken),
        };
        //return userId switch
        //{
        //    null => new List<ProductDto>(await ProductQuery()
        //                .Where(x => !x.Deleted)
        //                .Select(x => new ProductDto(x)).ToListAsync(cancellationToken)),
        //    _ => new List<ProductDto>(await ProductQuery()
        //    .Where(x => x.UserId == userId && !x.Deleted)
        //    .Select(x => new ProductDto(x)).ToListAsync(cancellationToken)),
        //};
    }

    public async Task<Product> GetProductAsync(int productId, CancellationToken cancellationToken)
    => await ProductQuery().FirstAsync(x => x.Id == productId && !x.Deleted, cancellationToken);

    private IQueryable<Product> ProductQuery() => _context.Products;


}
