namespace ApiCatalogoSecond.DTOs;

public class CategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProductDTO> Products { get; set; }
}
