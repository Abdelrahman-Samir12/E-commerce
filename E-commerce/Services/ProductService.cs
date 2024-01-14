using E_commerce.Interfaces;
using E_commerce.Models;

namespace E_commerce.Services
{
    public class ProductService : RepoistoryPattern<Product>,IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) : base(context) 
        { 
            _context = context;
        }
    }
}
