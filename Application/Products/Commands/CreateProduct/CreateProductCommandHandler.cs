using Domain.Abstractions;
using Domain.Entiys;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductWriteRepository _productRepository;

    public CreateProductCommandHandler(IProductWriteRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        Product product = new(1, command.product.Name, command.product.ProduceDate, command.product.ManufacturePhone,
            command.product.ManufactureEmail, command.product.IsAvailable, command.product.UserId);

        return await _productRepository.InsertAsync(product, cancellationToken);
    }
}
