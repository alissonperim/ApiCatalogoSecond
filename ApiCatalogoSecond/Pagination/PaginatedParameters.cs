namespace ApiCatalogoSecond.Pagination;

public class PaginatedParameters<T>
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public static ValueTask<PaginatedParameters<T>?> BindAsync(HttpContext context)
    {
        int.TryParse(context.Request.Query["pageNumber"], out var page);
        int.TryParse(context.Request.Query["pageSize"], out var pageSize);

        page = page == 0 ? 1 : page;
        pageSize = pageSize > 50 ? maxPageSize : pageSize;

        var result = new PaginatedParameters<T> { PageNumber = page, PageSize = pageSize };

        return ValueTask.FromResult<PaginatedParameters<T>?>( result );
    }
}
