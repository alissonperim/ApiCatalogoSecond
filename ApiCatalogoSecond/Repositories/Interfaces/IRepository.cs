using ApiCatalogoSecond.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoSecond.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<T> Add(T entity);
    public Task<ActionResult> Update(Guid id, T entity);
    public void Delete(Guid id);
    public Task<T> Get(Guid id);
    public IQueryable<T> Get();
    public Task<PagedList<T>> GetPaginated(PaginatedParameters<T> paginated);
}
