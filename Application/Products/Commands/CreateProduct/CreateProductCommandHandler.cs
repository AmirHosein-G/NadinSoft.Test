using Application.Products.Queries.GetProducts;
using Domain.Abstractions;
using Domain.Entiys;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductWriteRepository _productRepository;
    public readonly IMediator _mediator;

    public CreateProductCommandHandler(
        IMediator mediator,
        IProductWriteRepository productRepository)
    {
        _mediator = mediator;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        ProductsResponce products = await _mediator.Send(new GetProductsQuery(null), cancellationToken);
        if (products.Products.Any(x => 
        x.ManufactureEmail == command.Product.ManufactureEmail ||
        x.ProduceDate == command.Product.ProduceDate))
        {
            throw new Exception("Invalid data: ManufactureEmail or ProduceDate was repetitious!");
        }
        Product product = new(
            command.Product.Name, 
            command.Product.ProduceDate, 
            command.Product.ManufacturePhone,
            command.Product.ManufactureEmail, 
            command.Product.IsAvailable, 
            command.UserId);

        return await _productRepository.InsertAsync(product, cancellationToken);
    }
}
