using ApiCatalogoSecond.Data;
using ApiCatalogoSecond.Repositories.Interfaces;

namespace ApiCatalogoSecond.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private CategoriesRepository categoriesRepository;
        private ProductsRepository productsReopository;
        public Context _context;

        public UnityOfWork(Context context)
        {
            _context = context;
        }

        public ICategoriesRepository CategoriesRepository
        {
            get
            {
                return categoriesRepository ??= new CategoriesRepository(_context);
            }
        }

        public IProductsRepository ProductsRepository
        {
            get
            {
                return productsReopository ??= new ProductsRepository(_context);
            }
        }

        public async void Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
