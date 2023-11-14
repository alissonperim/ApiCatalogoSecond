using ApiCatalogoSecond.Domain.Entities;

namespace ApiCatalogoSecond.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public Guid CategoryId { get; set; }
}
