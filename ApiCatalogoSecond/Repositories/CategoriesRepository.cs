using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Domain.Entities;
using ApiCatalogoSecond.Repositories.Interfaces;

namespace ApiCatalogoSecond.Repositories;

public class CategoriesRepository : Repository<Category>, ICategoriesRepository
{
    public CategoriesRepository(Context context) : base(context) {}
}
