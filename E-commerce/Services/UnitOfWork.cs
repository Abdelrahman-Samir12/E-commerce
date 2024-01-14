using E_commerce.Interfaces;
using E_commerce.Models;

namespace E_commerce.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        //public IProduct Product;// TODO
        private readonly ApplicationDbContext _context;
        public ICategory Category { get; private set; }
        public IProduct Product { get; private set; }
        public IUser User { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryService(context);
            Product = new ProductService(context);
            User = new UserService(context);
        }


        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
