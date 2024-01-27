using Domain.Abstractions;
using Domain.Dto.ProductDtos;
using MediatR;

namespace Application.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, ProductsResponce>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetProductsQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<ProductsResponce> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        List<ProductDto> products = await _productReadRepository.GetProductsAsync(cancellationToken);

        return new ProductsResponce()
        {
            Products = products
        };
    }
}
