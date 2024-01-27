using Domain.Entiys;

namespace Domain.Dto.ProductDtos;

public class ProductDto
{
    public ProductDto(string name, DateTime produceDate, string manufacturePhone, string manufactureEmail, bool isAvailable)
    {
        Name = name;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        IsAvailable = isAvailable;
    }
    public ProductDto(Product product)
    {
        Name = product.Name;
        ProduceDate = product.ProduceDate;
        ManufacturePhone = product.ManufacturePhone;
        ManufactureEmail = product.ManufactureEmail;
        IsAvailable = product.IsAvailable;
    }

    public string Name { get; set; } = string.Empty;
    public DateTime ProduceDate { get; set; }
    public string ManufacturePhone { get; set; } = string.Empty;
    public string ManufactureEmail { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }

    public int UserId { get; set; }
}