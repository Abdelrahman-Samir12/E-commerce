using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_commerce.Services
{
    public class CategoryService : RepoistoryPattern<Category>, ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public List<Product> GetProductsByCategory(string categoryName)
        {
            var category = _context.Categories.Include(p => p.Products).SingleOrDefault(p => p.Name == categoryName);
            return category.Products;
        }
    } 
}
