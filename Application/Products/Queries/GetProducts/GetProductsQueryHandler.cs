﻿using Domain.Abstractions;
using Domain.Dto.ProductDtos;
using Domain.Entiys;
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
        List<Product> products = await _productReadRepository.GetProductsAsync(query.UserId, cancellationToken);

        return new ProductsResponce()
        {
            Products = products
        };
    }
}
