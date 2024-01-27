﻿namespace Domain.Dto.ProductDtos;

public class UpdateProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime ProduceDate { get; set; }
    public string ManufacturePhone { get; set; } = string.Empty;
    public string ManufactureEmail { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }

    public int UserId { get; set; }

}
