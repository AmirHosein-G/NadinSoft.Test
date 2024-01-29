using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entiys;

public class Product : Entity
{
    public Product(int id,
                   string name,
                   DateTime produceDate,
                   string manufacturePhone,
                   string manufactureEmail,
                   bool isAvailable,
                   int userId)
        : base(id)
    {
        Name = name;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        IsAvailable = isAvailable;
        UserId = userId;
    }
    public Product(string name, DateTime produceDate, string manufacturePhone, string manufactureEmail, bool isAvailable, int userId) 
    {
        Name = name;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        IsAvailable = isAvailable;
        UserId = userId;
    }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    public DateTime ProduceDate { get; set; } = DateTime.Now;
    [Required]
    [MaxLength(11)]
    public string ManufacturePhone { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string ManufactureEmail { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public bool Deleted { get; set; } = false;

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public void Update(string name, DateTime produceDate, string manufacturePhone, string manufactureEmail, bool isAvailable)
    {
        Name = name;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        IsAvailable = isAvailable;

    }
    // sice all the data in Db Should not be removed permently I will not delete a row direcly
    // usually i use a property whit the name of IsDeleted bu in this case i just turn the availbility of the products
    public void Delete()
    {
        Deleted = true;
    }
}
