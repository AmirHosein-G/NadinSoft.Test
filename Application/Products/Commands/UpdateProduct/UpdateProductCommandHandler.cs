using Domain.Abstractions;
using Domain.Entiys;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;

    public UpdateProductCommandHandler(
        IProductWriteRepository productWriteRepository,
        IProductReadRepository productReadRepository)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        Product product = await _productReadRepository.GetProductAsync(command.Product.Id, cancellationToken);

        if (product.UserId != command.UserId)
            throw new Exception("Access denied");
        
        product.Update(
            command.Product.Name, 
            command.Product.ProduceDate, 
            command.Product.ManufacturePhone,
            command.Product.ManufactureEmail, 
            command.Product.IsAvailable);

        return await _productWriteRepository.SaveChangesAsync(cancellationToken);
    }
}
