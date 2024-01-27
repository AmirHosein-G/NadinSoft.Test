using Domain.Dto.ProductDtos;

namespace Application.Products.Queries.GetProducts;

public class ProductsResponce
{
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
}
