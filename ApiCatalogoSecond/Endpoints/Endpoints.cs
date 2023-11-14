using ApiCatalogoSecond.Repositories;

namespace ApiCatalogoSecond.Endpoints;

public static class EndpointsMap
{
    public static void Endpoints(this WebApplication app)
    {
        app.CategoriesEndpoints();
        app.ProductsEndpoints();
    }
}
