namespace ApiCatalogoSecond.Repositories.Interfaces
{
    public interface IUnityOfWork
    {
        ICategoriesRepository CategoriesRepository { get; }
        IProductsRepository ProductsRepository { get; }
        void Commit();
    }
}
