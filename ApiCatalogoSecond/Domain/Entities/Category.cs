using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCatalogoSecond.Domain.Entities;

public class Category : Base
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [StringLength(300)]
    public string Description { get; set; }

    [JsonIgnore]
    public ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = new List<Product>();
    }
}
