using Domain.Abstractions;
using Domain.Entiys;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public DeleteProductCommandHandler(
        IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        Product product = await _productReadRepository.GetProductAsync(command.productId, cancellationToken);

        product.Delete();

        return await _productWriteRepository.SaveChangesAsync(cancellationToken);
    }
}
