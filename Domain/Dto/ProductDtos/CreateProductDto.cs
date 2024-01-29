namespace Domain.Dto.ProductDtos;

public class CreateProductDto
{
    public CreateProductDto(string name, DateTime produceDate, string manufacturePhone, string manufactureEmail, bool isAvailable)
    {
        Name = name;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        IsAvailable = isAvailable;
    }

    public string Name { get; set; } = string.Empty;
    public DateTime ProduceDate { get; set; }
    public string ManufacturePhone { get; set; } = string.Empty;
    public string ManufactureEmail { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
}