using Domain.Dto.ProductDtos;
using Domain.Entiys;

namespace Application.Products.Queries.GetProducts;

public class ProductsResponce
{
    public List<Product> Products { get; set; }
}
