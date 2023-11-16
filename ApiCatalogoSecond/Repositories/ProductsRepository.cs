using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Domain.Entities;
using ApiCatalogoSecond.DTOs;
using ApiCatalogoSecond.Pagination;
using ApiCatalogoSecond.Repositories.Interfaces;

namespace ApiCatalogoSecond.Repositories;

public class ProductsRepository : Repository<Product>, IProductsRepository
{
    public ProductsRepository(Context context) : base(context) {}
}
