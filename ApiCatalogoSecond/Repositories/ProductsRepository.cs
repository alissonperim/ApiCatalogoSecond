using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Domain.Entities;
using ApiCatalogoSecond.DTOs;
using ApiCatalogoSecond.Pagination;
using ApiCatalogoSecond.Repositories.Interfaces;

namespace ApiCatalogoSecond.Repositories;

public class ProductsRepository : Repository<Product>, IProductsRepository
{
    public ProductsRepository(Context context) : base(context) {}

    public IEnumerable<Product> GetPaginated(ProductsParameters parameters)
    {
        return Get().Result.OrderBy(o => o.Name).Skip((parameters.PageNumber - 1) * parameters.PageSize).ToList();
    }
}
