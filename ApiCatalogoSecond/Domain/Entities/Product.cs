using System.Text.Json.Serialization;

namespace ApiCatalogoSecond.Domain.Entities;

public class Product : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
    [JsonIgnore]
    public Category Category { get; set; }
}
