using Domain.Abstractions;
using Domain.Entiys;

namespace Infrastructure.WriteRepository;

public class ProductWriteRepository : IProductWriteRepository
{
    public IUnitOfWork UnitOfWork => _context;
    private readonly ApplicationDbContext _context;


    public ProductWriteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken)))
        { return true; }
        else
        { throw new Exception("Failed to save data"); }
    }

    public async Task<bool> InsertAsync(Product product, CancellationToken cancellationToken)
    {
        await _context.Set<Product>().AddAsync(product, cancellationToken);

        return await SaveChangesAsync(cancellationToken);
    }


}
