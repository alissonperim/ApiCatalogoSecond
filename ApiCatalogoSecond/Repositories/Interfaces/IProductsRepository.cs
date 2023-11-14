using ApiCatalogoSecond.Domain.Entities;
using ApiCatalogoSecond.DTOs;
using ApiCatalogoSecond.Pagination;

namespace ApiCatalogoSecond.Repositories.Interfaces;

public interface IProductsRepository : IRepository<Product>
{
    public IEnumerable<Product> GetPaginated(ProductsParameters? parameters);
}
