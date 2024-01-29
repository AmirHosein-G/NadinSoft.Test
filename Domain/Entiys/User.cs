using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entiys;

public class User : Entity
{
    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
    public User(int id, string userName, string password)
        : base(id)
    {
        UserName = userName;
        Password = password;
        _products = new List<Product>();
    }
    [MaxLength(500)]
    public string UserName { get; set; }
    [MaxLength(16)]
    public string Password { get; set; }

    private readonly List<Product> _products;
    public virtual IReadOnlyCollection<Product> Products => _products;


}
